using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PokemonPaint.Model;
using PokemonPaint.View;
using PokemonPaint.Commands;

namespace PokemonPaintTest
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void PokemonModelFactoryCreate()
        {
            PokemonModel bulba = PokemonModelFactory.Create(Pokemon.PokemonType.Bulbasaur);
            PokemonModel bulba2 = PokemonModelFactory.Create(Pokemon.PokemonType.Bulbasaur);
            PokemonModel dig = PokemonModelFactory.Create(Pokemon.PokemonType.Diglett);
            PokemonModel squirt = PokemonModelFactory.Create(Pokemon.PokemonType.Squirtle);
            PokemonModel pika = PokemonModelFactory.Create(Pokemon.PokemonType.Pikachu);
            PokemonModel slow = PokemonModelFactory.Create(Pokemon.PokemonType.Slowpoke);
            PokemonModel charm = PokemonModelFactory.Create(Pokemon.PokemonType.Charmander);

            Assert.AreEqual(bulba, bulba2);
            Assert.AreNotEqual(bulba, charm);
            Assert.AreSame(bulba, bulba2);
            Assert.AreSame(bulba, bulba2);

            Assert.AreEqual(bulba.GetType(), typeof(Bulbasaur));
            Assert.AreEqual(dig.GetType(), typeof(Diglett));
            Assert.AreEqual(squirt.GetType(), typeof(Squirtle));
            Assert.AreEqual(pika.GetType(), typeof(Pikachu));
            Assert.AreEqual(slow.GetType(), typeof(Slowpoke));
            Assert.AreEqual(charm.GetType(), typeof(Charmander));

        }

        [TestMethod]
        public void PokemonFactoryCreate()
        {
            Pokemon expected = new Pokemon()
            {
                Type = Pokemon.PokemonType.Bulbasaur,
                Location = new Point(15, 15),
                Model = PokemonModelFactory.Create(Pokemon.PokemonType.Bulbasaur),
                Size = new Size(40, 40),
                ID = 0
            };
            Pokemon actual = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));

            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Location, actual.Location);
            Assert.AreSame(expected.Model, actual.Model);
            Assert.AreEqual(expected.Size, actual.Size);
        }

        [TestMethod]
        public void PokemonFactoryCreateCopy()
        {
            Pokemon expected = new Pokemon()
            {
                Type = Pokemon.PokemonType.Bulbasaur,
                Location = new Point(15, 15),
                Model = PokemonModelFactory.Create(Pokemon.PokemonType.Bulbasaur),
                Size = new Size(40, 40),
                ID = 0
            };
            Pokemon actual2 = PokemonFactory.Create(expected);

            Assert.AreEqual(expected.Type, actual2.Type);
            Assert.AreEqual(expected.Location, actual2.Location);
            Assert.AreSame(expected.Model, actual2.Model);
            Assert.AreEqual(expected.Size, actual2.Size);
            Assert.AreNotEqual(expected.ID - 1, actual2.ID);
        }

        [TestMethod]
        public void PokemonFactoryCreateNull()
        {
            Pokemon expected = new Pokemon()
            {
                Type = Pokemon.PokemonType.Bulbasaur,
                Location = new Point(15, 15),
                Model = PokemonModelFactory.Create(Pokemon.PokemonType.Bulbasaur),
                Size = new Size(40, 40),
                ID = 0
            };
            Pokemon actual3 = PokemonFactory.Create(null);

            Assert.IsNull(actual3);
        }

        [TestMethod]
        public void PokemonFactoryCopy()
        {
            Pokemon expected = new Pokemon()
            {
                Type = Pokemon.PokemonType.Bulbasaur,
                Location = new Point(15, 15),
                Model = PokemonModelFactory.Create(Pokemon.PokemonType.Bulbasaur),
                Size = new Size(40, 40),
                ID = 0
            };
            Pokemon actual = PokemonFactory.Copy(expected);
            Pokemon actual2 = PokemonFactory.Copy(null);

            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Location, actual.Location);
            Assert.AreSame(expected.Model, actual.Model);
            Assert.AreEqual(expected.Size, actual.Size);
            Assert.AreEqual(expected.ID, actual.ID);

            Assert.IsNull(actual2);
        }

        [TestMethod]
        public void PokemonFactoryOverrideCount()
        {
            PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));

            PokemonFactory.OverrideCount(15);

            int id = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15)).ID;

            Assert.AreEqual(15, id);
        }

        [TestMethod]
        public void CommandFactoryCreate()
        {
            Pokemon bulba = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));

            Command actual = CommandFactory.Create(CommandFactory.CommandType.Create, bulba);
            Command actual2 = CommandFactory.Create(CommandFactory.CommandType.Move, bulba);
            Command actual3 = CommandFactory.Create(CommandFactory.CommandType.Delete, bulba);
            Command actual4 = CommandFactory.Create(CommandFactory.CommandType.Select, bulba);
            Command actual5 = CommandFactory.Create(CommandFactory.CommandType.Duplicate, bulba);
            Command actual6 = CommandFactory.Create(CommandFactory.CommandType.Shrink, bulba);
            Command actual7 = CommandFactory.Create(CommandFactory.CommandType.Grow, bulba);

            Assert.AreEqual(actual.GetType(), typeof(CreateCommand));
            Assert.AreEqual(actual2.GetType(), typeof(MoveCommand));
            Assert.AreEqual(actual3.GetType(), typeof(DeleteCommand));
            Assert.AreEqual(actual4.GetType(), typeof(SelectCommand));
            Assert.AreEqual(actual5.GetType(), typeof(DuplicateCommand));
            Assert.AreEqual(actual6.GetType(), typeof(ShrinkCommand));
            Assert.AreEqual(actual7.GetType(), typeof(GrowCommand));
        }
    }
}
