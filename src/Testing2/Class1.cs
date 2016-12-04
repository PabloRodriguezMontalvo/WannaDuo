using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RiotSharp.SummonerEndpoint;
using WannaDuo;
using WannaDuo.Controllers;
using WannaDuo.Model;
using WannaDuo.Repository;
using WannaDuo.Services;
using Xunit;
namespace Testing2
{

    public class AltasTest
    {

      
        private readonly Mock<Contexto> _dbContextMock = new Mock<Contexto>();
        private readonly HomeController _controller;

        [Fact]
        public void Buscar_InvocadorExiste_ShouldReturnFound()
        {
            var result = _controller.Buscar("elbos");
            result.Should().BeOfType<JsonResult>();
        }
        public AltasTest()
        {
        var mocu = new Mock<IRepositoryBase<Entrada>>();
        _controller= new HomeController(mocu.Object);
      
        }
    }
}
