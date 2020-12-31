using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain.Entities;
using Vaquinha.Domain.ViewModels;
using Xunit;

namespace Vaquinha.Tests.Common.Fixtures
{
    [CollectionDefinition(nameof(CausaFixtureCollection))]
    public class CausaFixtureCollection : ICollectionFixture<CausaFixture>
    {
    }

    public class CausaFixture
    {
        public CausaViewModel CausaModelValida()
        {
            var faker = new Faker<CausaViewModel>("pt_BR");

            var retorno = faker.Generate();

            retorno  = ModelValida();

            return retorno;
        }

        public Causa CausaInvalida(bool doacaoAnonima = false)
        {
            return new Causa(Guid.Empty, null, null, null);
        }

        public Causa CausaValida()
        {
            return new Causa(Guid.Empty, "nomeTeste", "cidadeTeste", "estadoTeste");
        }

        private CausaViewModel ModelValida()
        {
            var nome = new Faker().PickRandom<Name.Gender>();

            var faker = new Faker<CausaViewModel>("pt_BR");

            faker.RuleFor(a => a.Nome, (f, c) => f.Name.FirstName(nome));
            faker.RuleFor(a => a.Cidade, (f, c) => f.Address.City());
            faker.RuleFor(a => a.Estado, (f, c) => f.Address.State());

            return faker.Generate();
        }
    }
}
