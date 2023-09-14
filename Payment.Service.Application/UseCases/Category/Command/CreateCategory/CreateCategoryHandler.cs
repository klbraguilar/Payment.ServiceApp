using MediatR;
using Payment.Service.Application.UseCases.Client.Command.CreateClient;
using Payment.Service.Domain.Factories;
using Payment.Service.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Category.Command.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFactory _categoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, ICategoryFactory categoryFactory, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _categoryFactory = categoryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createdCategory = _categoryFactory.Create(request.Name);
            await _categoryRepository.CreateAsync(createdCategory);
            await _unitOfWork.Commit();
            return createdCategory.Id;
        }
    }
}
