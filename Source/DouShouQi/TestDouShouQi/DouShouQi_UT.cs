using DouShouQiLib;

namespace TestDouShouQi
{
    public class DouShouQi_UT
    {
        [Fact]
        public void ReglesMange_UT()
        {
            Piece souris = new Piece(PieceType.souris);
            Piece elephant = new Piece(PieceType.elephant);
            Piece chien = new Piece(PieceType.chien);

            IRegles regles = new regleOrigin();

            Assert.False(regles.Manger(elephant.Type, souris.Type));
            Assert.True(regles.Manger(souris.Type, elephant.Type));
            Assert.True(regles.Manger(elephant.Type, chien.Type));
            Assert.False(regles.Manger(souris.Type, chien.Type));
            Assert.True(regles.Manger(chien.Type, souris.Type));
            Assert.True(regles.Manger(chien.Type, chien.Type));

            regles = new regleVariente();

            Assert.True(regles.Manger(elephant.Type, souris.Type));
            Assert.True(regles.Manger(souris.Type, elephant.Type));
            Assert.True(regles.Manger(elephant.Type, chien.Type));
            Assert.False(regles.Manger(souris.Type, chien.Type));
            Assert.True(regles.Manger(chien.Type, souris.Type));
            Assert.True(regles.Manger(chien.Type, chien.Type));
        }

        [Fact]
        public void ReglesBouger_UT()
        {
            Piece souris = new Piece(PieceType.souris);
            Piece elephant = new Piece(PieceType.elephant);
            Piece chien = new Piece(PieceType.chien);
            Case eau = new Case(4, 5, CaseType.Eau);
            Case terre = new Case(4, 6, CaseType.Terre);

            IRegles regles = new regleOrigin();

            Assert.False(regles.Bouger(terre, elephant, eau, null));
            Assert.False(regles.Bouger(eau, souris, terre, elephant));
            Assert.True(regles.Bouger(eau, souris, eau, null));
            Assert.False(regles.Bouger(terre, chien, eau, null));
            Assert.True(regles.Bouger(terre, elephant, terre, chien));
            Assert.False(regles.Bouger(terre, elephant, terre, souris));
            Assert.True(regles.Bouger(terre, souris, terre, elephant));
            Assert.True(regles.Bouger(eau, souris, eau, souris));
            Assert.False(regles.Bouger(eau, souris, terre, souris));
            Assert.False(regles.Bouger(terre, elephant, eau, chien));

            regles = new regleVariente();

            Assert.False(regles.Bouger(terre, elephant, eau, null));
            Assert.False(regles.Bouger(eau, souris, terre, elephant));
            Assert.True(regles.Bouger(eau, souris, eau, null));
            Assert.True(regles.Bouger(terre, chien, eau, null));
            Assert.True(regles.Bouger(terre, elephant, terre, chien));
            Assert.True(regles.Bouger(terre, elephant, terre, souris));
            Assert.True(regles.Bouger(terre, souris, terre, elephant));
            Assert.True(regles.Bouger(eau, souris, eau, souris));
            Assert.False(regles.Bouger(eau, souris, terre, souris));
            Assert.True(regles.Bouger(eau, chien, eau, souris));
            Assert.True(regles.Bouger(eau, chien, eau, chien));
            Assert.True(regles.Bouger(terre, chien, terre, chien));
            Assert.True(regles.Bouger(terre, elephant, terre, chien));
            Assert.False(regles.Bouger(eau, souris, eau, chien));
            Assert.False(regles.Bouger(terre, elephant, eau, chien));
        }
    }
}