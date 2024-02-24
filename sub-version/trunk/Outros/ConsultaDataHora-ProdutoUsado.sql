select *, to_char(pudatahora, 'DD/MM/YYYY HH24:MI:SS') 
from produtousado where 
to_char(pudatahora, 'DD/MM/YYYY HH24:MI:SS') between '26/06/2021 17:43:05' and 
'26/06/2021 17:43:54'

select pudatahora from produtousado;
select pudatahora from produtousado;