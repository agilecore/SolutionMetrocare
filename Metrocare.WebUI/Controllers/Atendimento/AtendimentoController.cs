using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class AtendimentoController : Base                                 
    {                                                                               
        internal Atendimento _Atendimento { get; set; }                 
                                                                                    
        public AtendimentoController()                                        
        {                                                                           
            _Atendimento = new Atendimento();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionAtendimento = _Atendimento.GetAll().ToList(); 
            return View(collectionAtendimento);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new AtendimentoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(AtendimentoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Atendimento = new Atendimento();                    
                _Atendimento.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

