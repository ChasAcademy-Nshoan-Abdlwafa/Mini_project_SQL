ALTER TABLE "public"."nab_project_person" DROP CONSTRAINT "FK_nab_project_person_project_id";
ALTER TABLE "public"."nab_project_person" DROP CONSTRAINT "FK_nab_person_project_person_id";
DROP TABLE "public"."nab_project";
DROP TABLE "public"."nab_project_person";
DROP TABLE "public"."nab_person";
CREATE TABLE "public"."nab_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "nab_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."nab_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "nab_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."nab_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "nab_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."nab_project" ("id", "project_name") VALUES (19, 'Webbutik');
INSERT INTO "public"."nab_project" ("id", "project_name") VALUES (20, 'Agilt projekt');
INSERT INTO "public"."nab_project_person" ("id", "project_id", "person_id", "hours") VALUES (9, 19, 19, 5);
INSERT INTO "public"."nab_project_person" ("id", "project_id", "person_id", "hours") VALUES (10, 20, 20, 10);
INSERT INTO "public"."nab_person" ("id", "person_name") VALUES (19, 'Sebastian');
INSERT INTO "public"."nab_person" ("id", "person_name") VALUES (20, 'Lisa');
ALTER TABLE "public"."nab_project_person" ADD CONSTRAINT "FK_nab_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."nab_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."nab_project_person" ADD CONSTRAINT "FK_nab_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."nab_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;