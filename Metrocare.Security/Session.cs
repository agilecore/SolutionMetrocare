using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metrocare.Security.Models;
using Metrocare.Security.Interfaces;

namespace Metrocare.Security
{
    ///// <summary>
    ///// Métodos genéricos para manipulação de sessão dentro da aplicação.
    ///// </summary>
    //public class Session : ISessionOperation<AuthUser>
    //{
    //    /// <summary>
    //    /// Inicia uma sessão de acesso autorizado a aplicação.
    //    /// </summary>
    //    public void Start(AuthUser Model)
    //    {
    //        HttpContext.Current.Session["MetronicSession"] = Model;
    //    }

    //    /// <summary>
    //    /// Finaliza uma sessão de acesso autorizado a aplicação.
    //    /// </summary>
    //    public void Finish()
    //    {
    //        if (HttpContext.Current.Session["MetronicSession"] != null) { HttpContext.Current.Session.Abandon(); }
    //    }

    //    /// <summary>
    //    /// Retorna [true] se a sessão estiver ativa ou [false] se a sessão estiver inativa.
    //    /// </summary>
    //    public bool IsActive()
    //    {
    //        return ((HttpContext.Current.Session["MetronicSession"] != null) ? true : false);
    //    }

    //    /// <summary>
    //    /// Retorna o id da sessão autorizada.
    //    /// </summary>
    //    public string GetSessionId()
    //    {
    //      return ((HttpContext.Current.Session["MetronicSession"] != null) ? HttpContext.Current.Session.SessionID : String.Empty);
    //    }

    //    /// <summary>
    //    /// Retorna o objeto AuthenticatedUser armazenado na sessão atual.
    //    /// </summary>
    //    public AuthUser GetUser()
    //    {
    //       return ((HttpContext.Current.Session["MetronicSession"] != null) ? (AuthUser)HttpContext.Current.Session["MetronicSession"] : null); 
    //    }

    //    /// <summary>
    //    /// Retorna o tempo de duração em minutos configurado na aplicação.
    //    /// </summary>
    //    public Int32 GetSessionTimeOut()
    //    {
    //        return (HttpContext.Current.Session.Timeout);
    //    }

    //    /// <summary>
    //    /// Método que retorna o objeto mediante a verificação de seu tipo
    //    /// </summary>
    //    public TEntity Get<TEntity>(string SessionName)
    //    {
    //        return ((HttpContext.Current.Session[SessionName] is TEntity) ? (TEntity)HttpContext.Current.Session[SessionName] : default(TEntity));
    //    }

    //    /// <summary>
    //    /// Remove uma sessão específica
    //    /// </summary>
    //    public void Remove(string SessionName)
    //    {
    //        HttpContext.Current.Session.Remove(SessionName);
    //    }
    //}

    //public class Session<TEntity> where TEntity : class
    //{

    //    public void Start(TEntity Model, string SessionKey)
    //    {
    //        HttpContext.Current.Session[SessionKey] = Model;
    //    }


    //    public void Finish(string SessionKey)
    //    {
    //        if (HttpContext.Current.Session[SessionKey] != null) { HttpContext.Current.Session.Abandon(); }
    //    }


    //    public bool IsActive(string SessionKey)
    //    {
    //        return ((HttpContext.Current.Session[SessionKey] != null) ? true : false);
    //    }


    //    public string GetSessionId(string SessionKey)
    //    {
    //        return ((HttpContext.Current.Session[SessionKey] != null) ? HttpContext.Current.Session.SessionID : String.Empty);
    //    }   


    //    public Int32 GetSessionTimeOut()
    //    {
    //        return (HttpContext.Current.Session.Timeout);
    //    }


    //    public TEntity Get<TEntity>(string SessionKey)
    //    {
    //        return ((HttpContext.Current.Session[SessionKey] is TEntity) ? (TEntity)HttpContext.Current.Session[SessionKey] : default(TEntity));
    //    }


    //    public void Remove(string SessionKey)
    //    {
    //        HttpContext.Current.Session.Remove(SessionKey);
    //    }
    //}


    public class Session
    {

        public void Start(object Model, string SessionKey)
        {
            HttpContext.Current.Session[SessionKey] = Model;
        }


        public void Finish(string SessionKey)
        {
            if (HttpContext.Current.Session[SessionKey] != null) { HttpContext.Current.Session.Abandon(); }
        }


        public bool IsActive(string SessionKey)
        {
            var result = (HttpContext.Current.Session[SessionKey] != null) ? true : false;
            return (result);
        }


        public string GetSessionId(string SessionKey)
        {
            return ((HttpContext.Current.Session[SessionKey] != null) ? HttpContext.Current.Session.SessionID : String.Empty);
        }


        public Int32 GetSessionTimeOut()
        {
            return (HttpContext.Current.Session.Timeout);
        }


        //public object Get<T>(string SessionKey)
        //{
        //    return ((HttpContext.Current.Session[SessionKey] is <T>) ? (<T>)HttpContext.Current.Session[SessionKey] : default(<T>));
        //}


        public void Remove(string SessionKey)
        {
            HttpContext.Current.Session.Remove(SessionKey);
        }
    }
}