using Application.Contracts;
using Domian;
using Dtos.UserReview;
using MediatR;

namespace Application.Features.UserReviews.Command.CreateReview
{
    public class CreateUserReviewCommandHandler : IRequestHandler<CreateUserReviewCommand, UserReviewLargeDto>
    {
        private readonly IUserReviewRepository _userReviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository userRepository;

        public CreateUserReviewCommandHandler(IUserReviewRepository userReviewRepository,
            IProductRepository productRepository, IUserRepository userRepository)
        {
            _userReviewRepository = userReviewRepository;
            _productRepository = productRepository;
            this.userRepository = userRepository;
        }
        public async Task<UserReviewLargeDto> Handle(CreateUserReviewCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetDetailsAsync(request.ProductId);
            // var user = await userRepository.

            UserReview ur = new UserReview
            {
                Comment = request.Comment,
                RatingValue = request.RatingValue,
                Date = DateTime.Now,
                Product = product,
                //User=
            };

            await _userReviewRepository.CreateAsync(ur);
            return new UserReviewLargeDto
            {
                Comment = request.Comment,
                RatingValue = request.RatingValue,
                Date = ur.Date,
               // ProductName = product.Name,
                UserName = "adel"

            };
        }
    }
}
