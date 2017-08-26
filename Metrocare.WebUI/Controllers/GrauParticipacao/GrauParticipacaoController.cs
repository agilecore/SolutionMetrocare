using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class GrauParticipacaoController : Base                                 
    {                                                                               
        internal GrauParticipacao _GrauParticipacao { get; set; }                 
                                                                                    
        public GrauParticipacaoController()                                        
        {                                                                           
            _GrauParticipacao = new GrauParticipacao();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionGrauParticipacao = _GrauParticipacao.GetAll().ToList(); 
            return View(collectionGrauParticipacao);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new GrauParticipacaoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(GrauParticipacaoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var GrauParticipacao = new GrauParticipacao();                    
                _GrauParticipacao.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

