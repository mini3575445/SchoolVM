--CTE(common table expression)

--�аȨt��-�D�޸�ƪ�AER�ϤW���@�����Y

select ���u�r�� from �D�� where �D�ަr�� in (
select ���u�r�� from �D�� where �D�ަr�� is null)


--CTE:
with test
as
(
--�o�̩�select
)
------------------
--CTE�̱`�Φb���j
--Recursive���j
with �D�޶��h
as
(
select �m�W, 1 as �h��,���u�r�� from �D�� where �D�ަr�� is null
union all
select �D��.�m�W ,�h��+1 as �h�� , �D��.���u�r�� from �D�� inner join �D�޶��h
on �D��.�D�ަr��=�D�޶��h.���u�r��
)
select �D�޶��h.�m�W,�D�޶��h.�h�� from �D�޶��h
order by �D�޶��h.�h��
