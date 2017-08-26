using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class LogPlanoController : Base                                 
    {                                                                               
        internal LogPlano _LogPlano { get; set; }                 
                                                                                    
        public LogPlanoController()                                        
        {                                                                           
            _LogPlano = new LogPlano();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionLogPlano = _LogPlano.GetAll().ToList(); 
            return View(collectionLogPlano);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new LogPlanoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(LogPlanoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var LogPlano = new LogPlano();                    
                _LogPlano.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

