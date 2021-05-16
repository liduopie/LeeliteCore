CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20200401005504_InitialSettings') THEN
    CREATE TABLE "Settings_SettingValue" (
        "TenantId" bigint NOT NULL,
        "UserId" bigint NOT NULL,
        "Name" character varying(256) NOT NULL,
        "Value" character varying(1024) NULL,
        CONSTRAINT "PK_Settings_SettingValue" PRIMARY KEY ("TenantId", "UserId", "Name")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20200401005504_InitialSettings') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20200401005504_InitialSettings', '5.0.6');
    END IF;
END $$;
COMMIT;

