using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class EspecialidadeController : Base                                 
    {                                                                               
        internal Especialidade _Especialidade { get; set; }                 
                                                                                    
        public EspecialidadeController()                                        
        {                                                                           
            _Especialidade = new Especialidade();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionEspecialidade = _Especialidade.GetAll().ToList(); 
            return View(collectionEspecialidade);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new EspecialidadeDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(EspecialidadeDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Especialidade = new Especialidade();                    
                _Especialidade.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

