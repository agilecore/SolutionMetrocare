using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class PlanoController : Base                                 
    {                                                                               
        internal Plano _Plano { get; set; }                 
                                                                                    
        public PlanoController()                                        
        {                                                                           
            _Plano = new Plano();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionPlano = _Plano.GetAll().ToList(); 
            return View(collectionPlano);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new PlanoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(PlanoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Plano = new Plano();                    
                _Plano.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

