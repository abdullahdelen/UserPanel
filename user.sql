PGDMP                         |            dbLocal    13.14    13.14 	    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16394    dbLocal    DATABASE     f   CREATE DATABASE "dbLocal" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE "dbLocal";
                postgres    false            �            1259    16395    Users    TABLE     $  CREATE TABLE public."Users" (
    "TCNO" character varying(11) NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Surname" character varying(50) NOT NULL,
    "Status" boolean,
    "CreatedDate" date NOT NULL,
    "UpdatedDate" date,
    "Id" integer NOT NULL,
    "BirthDate" date
);
    DROP TABLE public."Users";
       public         heap    postgres    false            �            1259    16437    Users_Id_seq    SEQUENCE     �   ALTER TABLE public."Users" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Users_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    200            �          0    16395    Users 
   TABLE DATA           w   COPY public."Users" ("TCNO", "Name", "Surname", "Status", "CreatedDate", "UpdatedDate", "Id", "BirthDate") FROM stdin;
    public          postgres    false    200   ?	       �           0    0    Users_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Users_Id_seq"', 30, true);
          public          postgres    false    201            #           2606    16399    Users Users_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("TCNO");
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public            postgres    false    200            �      x������ � �     