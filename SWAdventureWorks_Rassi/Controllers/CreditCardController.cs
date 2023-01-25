using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SWAdventureWorks_Rassi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Rassi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;

        public CreditCardController(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<CreditCard>> Get()
        {
            return context.CreditCard.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<CreditCard> GetById(int id)//traer por id
        {
            CreditCard CreditCard = (from a in context.CreditCard
                           where a.CreditCardId == id
                           select a).SingleOrDefault();
            return CreditCard;
        }

        [HttpGet("CardType/{CardType}")]//rutas personalizadas
        public ActionResult<IEnumerable<CreditCard>> GetCardType(string CardType)
        {
            List<CreditCard> creditCards = (from a in context.CreditCard
                                            where a.CardType == CardType
                                            select a).ToList();
            return creditCards;
        }

        [HttpPost]
        public ActionResult Post(CreditCard creditCard) //INSERT
        {
            if (!ModelState.IsValid)//si no es valido
            {
                return BadRequest(ModelState);//digo error
            }
            context.CreditCard.Add(creditCard);//agrego
            context.SaveChanges();//y guardo
            return Ok();
        }
    }

}


