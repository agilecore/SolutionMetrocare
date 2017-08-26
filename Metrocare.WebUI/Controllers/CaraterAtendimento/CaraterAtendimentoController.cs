using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class CaraterAtendimentoController : Base                                 
    {                                                                               
        internal CaraterAtendimento _CaraterAtendimento { get; set; }                 
                                                                                    
        public CaraterAtendimentoController()                                        
        {                                                                           
            _CaraterAtendimento = new CaraterAtendimento();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionCaraterAtendimento = _CaraterAtendimento.GetAll().ToList(); 
            return View(collectionCaraterAtendimento);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new CaraterAtendimentoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(CaraterAtendimentoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var CaraterAtendimento = new CaraterAtendimento();                    
                _CaraterAtendimento.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

