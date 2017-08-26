using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class LogAcessoController : Base                                 
    {                                                                               
        internal LogAcesso _LogAcesso { get; set; }                 
                                                                                    
        public LogAcessoController()                                        
        {                                                                           
            _LogAcesso = new LogAcesso();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionLogAcesso = _LogAcesso.GetAll().ToList(); 
            return View(collectionLogAcesso);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new LogAcessoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(LogAcessoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var LogAcesso = new LogAcesso();                    
                _LogAcesso.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

