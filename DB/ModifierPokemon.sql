﻿CREATE PROCEDURE [dbo].[ModifierPokemon]
	@ID int,
	@NOM VARCHAR(50),
	@ELEMENT INT,
    @MAXPV INT,
    @PV INT,
    @ATTAQUE1 INT,
    @ATTAQUE2 INT,
    @JOUEUR INT

AS
BEGIN
    -- Insertion de la nouvelle personne dans la table
    UPDATE Pokemon SET NOM=@NOM,ELEMENT=@ELEMENT,MAXPV=@MAXPV,PV=@PV,ATTAQUE1=@ATTAQUE1,ATTAQUE2=@ATTAQUE2,JOUEUR=@JOUEUR WHERE ID=@ID


    RETURN 0;
END;