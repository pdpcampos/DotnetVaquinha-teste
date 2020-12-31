using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain;
using Vaquinha.Repository;
using Vaquinha.Repository.Context;
using Xunit;

namespace Vaquinha.Unit.Tests.RepositoryTests
{
    public class HomeRepositoryTests
    {
        private readonly Mock<IHomeInfoRepository> _homeRepository = new Mock<IHomeInfoRepository>();
        
        private readonly VaquinhaOnlineDBContext _dbContext;

        private HomeInfoRepository _homeInfoRepository;
        private readonly IHomeInfoRepository _homeInfoIRepository;

        public HomeRepositoryTests()
        {
            _homeInfoIRepository = new HomeInfoRepository(_dbContext);

            _homeInfoIRepository = new HomeInfoRepository(_dbContext);
        }

        #region Testes método "RecuperarCausas"

        [Fact]
        [Trait("HomeRepository", "HomeInfo_RecuperarDadosIniciaisHomeAsync_Valida")]
        public void HomeInfo_RecuperarDadosIniciaisHomeAsync_Valida()
        {
            // Arrange
            _homeInfoRepository = new HomeInfoRepository(_dbContext);

            // Act
            var retorno = _homeInfoRepository.RecuperarDadosIniciaisHomeAsync();

            Assert.True(retorno.IsCompleted);
        }

        #endregion

    }
}
