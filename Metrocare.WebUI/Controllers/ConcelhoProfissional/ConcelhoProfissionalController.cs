using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class ConcelhoProfissionalController : Base                                 
    {                                                                               
        internal ConcelhoProfissional _ConcelhoProfissional { get; set; }                 
                                                                                    
        public ConcelhoProfissionalController()                                        
        {                                                                           
            _ConcelhoProfissional = new ConcelhoProfissional();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionConcelhoProfissional = _ConcelhoProfissional.GetAll().ToList(); 
            return View(collectionConcelhoProfissional);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new ConcelhoProfissionalDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(ConcelhoProfissionalDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var ConcelhoProfissional = new ConcelhoProfissional();                    
                _ConcelhoProfissional.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

