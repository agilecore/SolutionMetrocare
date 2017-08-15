delimiter $$

drop procedure if exists sp_adiciona_usuario$$

create definer=`saude`@`%` procedure `sp_adiciona_usuario`(
    in v_id_usuario    int         ,            
    in v_nome          varchar(255), 
    in v_cpf           varchar(30) , 
	in v_rg            varchar(30) , 
    in v_logradouro    varchar(255), 
    in v_complemento   varchar(255), 
    in v_numero        int         , 
    in v_cep           int         , 
    in v_bairro        varchar(255), 
    in v_cidade        varchar(255), 
    in v_uf            varchar(2)  , 
    in v_email         varchar(30) , 
    in v_telefone      varchar(15) , 
    in v_celular       varchar(15) , 
    in v_contato       varchar(255), 
    in v_dt_cadastro   date        , 
    in v_dt_nascimento date        , 
    in v_longitude     int         , 
    in v_latitude      int         , 
    in v_ibge          int         , 
    in v_senha         varchar(255), 
    in v_status        char(1)      
)
begin

    if exists (select id_usuario from usuario where id_usuario = v_id_usuario) then

        update usuario 
           set nome          = v_nome          ,
               cpf           = v_cpf           ,
			   rg            = v_rg            ,
               logradouro    = v_logradouro    ,
               complemento   = v_complemento   ,
               numero        = v_numero        ,
               cep           = v_cep           ,
               bairro        = v_bairro        ,
               cidade        = v_cidade        ,
               uf            = v_uf            ,
               email         = v_email         ,
               telefone      = v_telefone      ,
               celular       = v_celular       ,
               contato       = v_contato       ,
               dt_cadastro   = v_dt_cadastro   ,
               dt_nascimento = v_dt_nascimento ,
               longitude     = v_longitude     ,
               latitude      = v_latitude      ,
               ibge          = v_ibge          ,
               senha         = v_senha         ,
               status        = v_status 
         where id_usuario = v_id_usuario;
         commit;

    else

        insert into usuario 
        (
            id_usuario       ,                 
            nome             ,               
            cpf              ,  
			rg               ,  			
            logradouro       ,               
            complemento      ,               
            numero           ,               
            cep              ,               
            bairro           ,               
            cidade           ,               
            uf               ,               
            email            ,               
            telefone         ,               
            celular          ,               
            contato          ,               
            dt_cadastro      ,               
            dt_nascimento    ,               
            longitude        ,               
            latitude         ,               
            ibge             ,               
            senha            ,               
            status           
        )                    
        values               
        (                    
            v_id_usuario     ,                 
            v_nome           ,               
            v_cpf            , 
			v_rg             ,
            v_logradouro     ,               
            v_complemento    ,               
            v_numero         ,               
            v_cep            ,               
            v_bairro         ,               
            v_cidade         ,               
            v_uf             ,               
            v_email          ,               
            v_telefone       ,               
            v_celular        ,               
            v_contato        ,               
            v_dt_cadastro    ,               
            v_dt_nascimento  ,               
            v_longitude      ,               
            v_latitude       ,               
            v_ibge           ,               
            v_senha          ,               
            v_status         
        );  
        commit;

    end if;

end$$

delimiter ;