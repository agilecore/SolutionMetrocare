using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class CredenciadoController : Base                                 
    {                                                                               
        internal Credenciado _Credenciado { get; set; }                 
                                                                                    
        public CredenciadoController()                                        
        {                                                                           
            _Credenciado = new Credenciado();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionCredenciado = _Credenciado.GetAll().ToList(); 
            return View(collectionCredenciado);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new CredenciadoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(CredenciadoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Credenciado = new Credenciado();                    
                _Credenciado.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

