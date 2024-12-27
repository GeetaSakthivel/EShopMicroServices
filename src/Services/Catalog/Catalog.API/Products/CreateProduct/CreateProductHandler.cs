namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(Guid Id,string Name, List<string> Category, string Description, string Imagefile, decimal Price):
        ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public  class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is Required");
            RuleFor(x => x.Imagefile).NotEmpty().WithMessage("Imagefile is Required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be geater than Zero");
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            
            //Create Product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Imagefile = command.Imagefile,
                Price = command.Price
            };
            //Save to Database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return CreateProductResult result
            return new CreateProductResult(product.Id);
            
        }
    }
}

