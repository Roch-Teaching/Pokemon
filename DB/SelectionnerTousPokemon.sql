CREATE PROCEDURE [dbo].[SelectionnerTousPokemon]

AS
BEGIN

    -- Lecture des personnes dans la table
    SELECT ID,NOM,ELEMENT,MAXPV,PV,ATTAQUE1,ATTAQUE2,JOUEUR FROM Pokemon


    RETURN 0;
END;