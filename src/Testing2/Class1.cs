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
        private readonly Claves _claves;

        [Fact]
        public void Buscar_InvocadorExiste_ShouldReturnFound()
        {
            var result = _controller.Buscar("elbos");
            result.Should().BeOfType<JsonResult>();
        }
        [Fact]
        public void Buscar_InvocadorNoExiste_ShouldReturnNotFound()
        {
            var result = _controller.Buscar("xxxelbosxxx");
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void GenerarClave_GetString_ShouldReturnString()
        {


            var result = _claves.DameClave();
            result.Should().BeOfType<string>();
           ;
        }
        [Fact]
        public void GetFirstMasteriePageName_GetName_ShouldReturnString()
        {
            var result = _controller.GetFirstMasteriePageName(20009728);
            result.Should().BeOfType<string>();
        }
    
        public AltasTest()
        {
        var mocu = new Mock<IRepositoryBase<Entrada>>();
        _controller= new HomeController(mocu.Object);
            _claves= new Claves();
      
        }
    }
}
