delimiter $$

drop procedure if exists sp_adiciona_dependente$$

create procedure sp_adiciona_dependente
(
      v_id_dependente    int          ,              
      v_id_beneficiario  int          ,   
      v_id_parentesco    int          ,   
      v_id_carteira      int          ,   
      v_id_usuario       int          ,   
      v_nome             varchar(255) ,   
      v_cpf              varchar(255) ,   
      v_rg               varchar(255) ,   
      v_logradouro       varchar(255) ,   
      v_complemento      varchar(255) ,   
      v_numero           int          ,   
      v_cep              int          ,   
      v_bairro           varchar(255) ,   
      v_cidade           varchar(255) ,   
      v_uf               varchar(2)   ,   
      v_email            varchar(255) ,   
      v_dt_cadastro      date        
)
begin

    if exists (select id_dependente from dependente where id_dependente = v_id_dependente) then

        update dependente 
           set id_dependente   = v_id_dependente   ,
               id_beneficiario = v_id_beneficiario ,
               id_parentesco   = v_id_parentesco   ,
               id_carteira     = v_id_carteira     ,
               id_usuario      = v_id_usuario      ,
               nome            = v_nome            ,
               cpf             = v_cpf             ,
               rg              = v_rg              ,
               logradouro      = v_logradouro      ,
               complemento     = v_complemento     ,
               numero          = v_numero          ,
               cep             = v_cep             ,
               bairro          = v_bairro          ,
               cidade          = v_cidade          ,
               uf              = v_uf              ,
               email           = v_email           ,
               dt_cadastro     = v_dt_cadastro     
         where id_dependente   = id_dependente;
         commit;

    else

        insert into dependente 
        (
            id_dependente     ,                 
            id_beneficiario   ,             
            id_parentesco     ,             
            id_carteira       ,             
            id_usuario        ,             
            nome              ,             
            cpf               ,             
            rg                ,             
            logradouro        ,             
            complemento       ,             
            numero            ,             
            cep               ,             
            bairro            ,             
            cidade            ,             
            uf                ,             
            email             ,             
            dt_cadastro         
        )                    
        values               
        (                    
            v_id_dependente   ,                 
            v_id_beneficiario ,             
            v_id_parentesco   ,             
            v_id_carteira     ,             
            v_id_usuario      ,             
            v_nome            ,             
            v_cpf             ,             
            v_rg              ,             
            v_logradouro      ,             
            v_complemento     ,             
            v_numero          ,             
            v_cep             ,             
            v_bairro          ,             
            v_cidade          ,             
            v_uf              ,             
            v_email           ,             
            v_dt_cadastro     
        );  
        commit;

    end if;

end$$

delimiter ;