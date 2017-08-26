using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class CredenciadoEspecialidadeController : Base                                 
    {                                                                               
        internal CredenciadoEspecialidade _CredenciadoEspecialidade { get; set; }                 
                                                                                    
        public CredenciadoEspecialidadeController()                                        
        {                                                                           
            _CredenciadoEspecialidade = new CredenciadoEspecialidade();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionCredenciadoEspecialidade = _CredenciadoEspecialidade.GetAll().ToList(); 
            return View(collectionCredenciadoEspecialidade);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new CredenciadoEspecialidadeDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(CredenciadoEspecialidadeDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var CredenciadoEspecialidade = new CredenciadoEspecialidade();                    
                _CredenciadoEspecialidade.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

