CREATE PROCEDURE [dbo].[SelectionnerPokemonJoueur]
@JOUEUR int
AS
BEGIN

    -- Lecture des pokemon du joueur dans la table
    SELECT ID,NOM,ELEMENT,MAXPV,PV,ATTAQUE1,ATTAQUE2,JOUEUR FROM Pokemon
	WHERE JOUEUR=@JOUEUR


    RETURN 0;
END;