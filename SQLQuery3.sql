select * from Funcionario f
inner join Empresa e
on e.Id = f.EmpresaId
order by f.nome asc