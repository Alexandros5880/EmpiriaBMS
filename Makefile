
ci-staging:
	git tag -d v0.0.1-staging
	git push origin -d v0.0.1-staging
	git add *
	git commit -m "Save"
	git push
	git tag v0.0.1-staging
	git push origin v0.0.1-staging

ci-production:
	git tag -d v0.0.1-production
	git push origin -d v0.0.1-production
	git add *
	git commit -m "Save"
	git push
	git tag v0.0.1-production
	git push origin v0.0.1-production


dropdb:
	SUBDIR := EmpiriaBMS.EF.CLI
	MIGRATIONSDIR := Migrations
	@cd $(SUBDIR) && \
	@rd /s /q $(MIGRATIONSDIR)
	@dotnet ef database drop -f -v