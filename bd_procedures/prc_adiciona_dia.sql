delimiter $$

drop procedure if exists sp_adiciona_dia$$

create procedure sp_adiciona_dia
(   
    in v_id_dia      				   	         int  ,
    in v_nome                            varchar(30)  ,
    in v_sigla                           varchar(30)  
)
begin

    if exists (select id_dia from dia where id_dia = v_id_dia) then

        update dia 
           set nome   = v_nome  ,       
               sigla  = v_sigla     
         where id_dia = v_id_dia;
         commit;

    else

        insert into dia 
        (
            id_dia    , 
            nome      , 
            sigla     
        )                     
        values                
        (             
            v_id_dia  ,   
            v_nome    ,  
            v_sigla   
        );  
        commit;

    end if;

end$$ 

delimiter ;