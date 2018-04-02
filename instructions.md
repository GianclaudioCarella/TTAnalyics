* Primeiro passo:

Rodar no Package Manager Console as 3 linhas abaixo (uma por vez, na seguinte ordem):

enable-migrations -projectname TTAnalytics.Data -StartUpprojectname TTAnalytics.API -Verbose

add-migration -projectname TTAnalytics.Data InitialDatabase

update-database -projectname TTAnalytics.Data