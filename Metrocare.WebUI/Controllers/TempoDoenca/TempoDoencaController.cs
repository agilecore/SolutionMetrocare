using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TempoDoencaController : Base                                 
    {                                                                               
        internal TempoDoenca _TempoDoenca { get; set; }                 
                                                                                    
        public TempoDoencaController()                                        
        {                                                                           
            _TempoDoenca = new TempoDoenca();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTempoDoenca = _TempoDoenca.GetAll().ToList(); 
            return View(collectionTempoDoenca);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TempoDoencaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TempoDoencaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TempoDoenca = new TempoDoenca();                    
                _TempoDoenca.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

