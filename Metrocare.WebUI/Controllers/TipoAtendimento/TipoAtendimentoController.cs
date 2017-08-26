using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TipoAtendimentoController : Base                                 
    {                                                                               
        internal TipoAtendimento _TipoAtendimento { get; set; }                 
                                                                                    
        public TipoAtendimentoController()                                        
        {                                                                           
            _TipoAtendimento = new TipoAtendimento();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTipoAtendimento = _TipoAtendimento.GetAll().ToList(); 
            return View(collectionTipoAtendimento);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TipoAtendimentoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TipoAtendimentoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TipoAtendimento = new TipoAtendimento();                    
                _TipoAtendimento.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

