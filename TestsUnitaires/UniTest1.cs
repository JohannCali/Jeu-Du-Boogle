using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_S1_BRUGERE_CALI;

namespace Projet_S1_BRUGERE_CALI
{
    [TestClass]
    public class JoueurTests
    {
        [TestMethod]
        public void Test_Add_Mot()
        {
            // Arrange
            char lettrefacevisible = 'x';
            List<char> liste = new List<char> { 'a', 'b', 'c' }; // Liste initiale
            Dé dé = new Dé(liste);                               // Création d'un dé avec des lettres 
            Plateau plateau = new Plateau(lettrefacevisible, liste, dé, 2); // Créer une instance fictive de Plateau
            List<string> motsTrouves = new List<string> { "a", "b", "c" }; // Liste de mots trouvés initiale
            var joueur = new Joueur("Patrick", 5, motsTrouves, 3, plateau);

            // Act
            joueur.Add_Mot("d");

            // Assert
            Assert.AreEqual(4, joueur.Motstrouvés.Count);
            Assert.IsTrue(joueur.Motstrouvés.Contains("d"));
            Assert.AreEqual(4, joueur.Occurences);
            Assert.AreNotEqual(5, joueur.Motstrouvés.Count);
        }

        [TestMethod]
        public void Test_AffichageMotstrouvés()
        {
            // Arrange
            char lettrefacevisible = 'x';
            List<char> liste = new List<char> { 'a', 'b', 'c' }; // Liste initiale
            Dé dé = new Dé(liste); // Création d'un dé avec des lettres 
            Plateau plateau = new Plateau(lettrefacevisible, liste, dé, 2); // Créer une instance fictive de Plateau
            List<string> motsTrouves = new List<string> { "a", "b", "c" }; // Liste de mots trouvés initiale
            var joueur = new Joueur("Patrick", 5, motsTrouves, 3, plateau);

            // Act
            var result = joueur.AffichageMotstrouvés(joueur.Motstrouvés);

            // Assert
            Assert.AreEqual("a b c ", result);
            Assert.AreNotEqual("aaaaaa", result);
        }
    }


    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void Test_Test_Plateau()
        {
            // Arrange
            List<char> listeFaces = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' }; // Liste de faces 
            Dé dé = new Dé(listeFaces); // Création d'un dé avec des lettres 
            char[,] matrice = {
                                { 'A', 'B', 'C' },
                                { 'D', 'E', 'F' },
                                { 'G', 'H', 'I' }
                                };
            var plateau = new Plateau('A', listeFaces, dé, 3);

            // Act
            bool result = plateau.Test_Plateau("ABCF", matrice); // Tester un mot qui existe
            bool result1 = plateau.Test_Plateau("GHC", matrice);
            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(result1);
        }
    }


    [TestClass]
    public class DéTests
    {
        [TestMethod]
        public void Test_ListeToString()
        {
            // Arrange
            List<char> lettresPossibles = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            var dé = new Dé(lettresPossibles);

            // Act
            string resultat = dé.ListeToString(dé.ListeLettresFaces);

            // Assert
            foreach (char lettre in dé.ListeLettresFaces)
            {
                Assert.IsTrue(resultat.Contains(lettre.ToString()));
            }
        }

        [TestMethod]
        public void Test_Affichage()
        {
            // Arrange
            List<char> lettresPossibles = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            var dé = new Dé(lettresPossibles);

            // Act
            char affichageResultat = dé.Affichage();

            // Assert
            Assert.AreEqual(dé.LettreFaceVisible, affichageResultat);
        }
    }
}