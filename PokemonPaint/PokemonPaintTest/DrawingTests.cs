using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PokemonPaint.Model;
using PokemonPaint.View;
using PokemonPaint.Commands;

namespace PokemonPaintTest
{
    [TestClass]
    public class DrawingTests
    {
        Drawing drawing;

        [TestInitialize]
        public void Init()
        {
            drawing = Drawing.Create(null, Color.WhiteSmoke);
        }

        [TestMethod]
        public void PokemonAtRectangle()
        {
            Pokemon expected = PokemonFactory.Create(Pokemon.PokemonType.Charmander, new Point(15, 15));
            drawing.PokemonList.Add(expected.ID, expected);

            Pokemon actual = drawing.PokemonAtRectangle(new Rectangle(15, 15, 1, 1));

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void DoCreate()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);

            drawing.Do(c);

            Assert.AreEqual(1, drawing.PokemonList.Count);
            Assert.AreSame(p, drawing.PokemonList[p.ID]);

            Command badC = CommandFactory.Create(CommandFactory.CommandType.Create, null);

            try {
                drawing.Do(badC);
            }catch(Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UndoCreate()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);

            drawing.Do(c);
            drawing.Undo();

            Pokemon outP;
            Assert.IsFalse(drawing.PokemonList.TryGetValue(p.ID, out outP));
        }

        [TestMethod]
        public void DoDelete()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Command d = CommandFactory.Create(CommandFactory.CommandType.Delete, p);
            Command badD  = CommandFactory.Create(CommandFactory.CommandType.Delete, null);

            drawing.Do(c);
            drawing.Do(d);

            Pokemon outP;
            Assert.IsFalse(drawing.PokemonList.TryGetValue(p.ID, out outP));

            try
            {
                drawing.Do(badD);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UndoDelete()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Command d = CommandFactory.Create(CommandFactory.CommandType.Delete, p);

            drawing.Do(c);
            drawing.Do(d);
            drawing.Undo();

            Assert.AreSame(p, drawing.PokemonList[p.ID]);
        }

        [TestMethod]
        public void DoDuplicate()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Pokemon dup = PokemonFactory.Create(p);
            
            Command d = CommandFactory.Create(CommandFactory.CommandType.Duplicate, dup);
            Command badD = CommandFactory.Create(CommandFactory.CommandType.Duplicate, null);

            drawing.Do(c);
            drawing.Do(d);

            dup = drawing.PokemonList[dup.ID];
            Assert.AreEqual(p.Type, dup.Type);
            Assert.AreEqual(new Point(35, 35), dup.Location);
            Assert.AreSame(p.Model, dup.Model);
            Assert.AreEqual(p.Size, dup.Size);

            try
            {
                drawing.Do(badD);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UndoDuplicate()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Pokemon dup = PokemonFactory.Create(p);
            Command d = CommandFactory.Create(CommandFactory.CommandType.Duplicate, dup);

            drawing.Do(c);
            drawing.Do(d);
            drawing.Undo();

            Pokemon outP;
            Assert.IsFalse(drawing.PokemonList.TryGetValue(dup.ID, out outP));
        }

        [TestMethod]
        public void DoGrow()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);

            Command g = CommandFactory.Create(CommandFactory.CommandType.Grow, p);
            Command badG = CommandFactory.Create(CommandFactory.CommandType.Shrink, null);

            Size expected = new Size(p.Size.Width + GrowCommand.GROWTH_FACTOR, p.Size.Height + GrowCommand.GROWTH_FACTOR);

            drawing.Do(c);
            drawing.Do(g);

            Assert.AreEqual(expected, p.Size);

            try
            {
                drawing.Do(badG);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UndoGrow()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Command g = CommandFactory.Create(CommandFactory.CommandType.Grow, p);

            Size expected = p.Size;

            drawing.Do(c);
            drawing.Do(g);
            drawing.Undo();

            Assert.AreEqual(expected, p.Size);
        }

        [TestMethod]
        public void DoMove()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Pokemon moveMe = PokemonFactory.Copy(p);
            moveMe.Location = new Point(25, 25);
            Command m = CommandFactory.Create(CommandFactory.CommandType.Move, moveMe);
            Command badM = CommandFactory.Create(CommandFactory.CommandType.Move, null);

            Point expected = new Point(moveMe.Location.X - moveMe.Size.Width / 2,
                                         moveMe.Location.Y - moveMe.Size.Height / 2);

            drawing.Do(c);
            drawing.Do(m);

            Assert.AreEqual(expected, p.Location);

            try
            {
                drawing.Do(badM);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UndoMove()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Pokemon moveMe = PokemonFactory.Copy(p);
            moveMe.Location = new Point(50, 50);
            Command m = CommandFactory.Create(CommandFactory.CommandType.Move, moveMe);

            drawing.Do(c);
            Point expected = p.Location;

            drawing.Do(m);
            drawing.Undo();

            Assert.AreEqual(expected, p.Location);
        }

        [TestMethod]
        public void DoSelect()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);

            Command s = CommandFactory.Create(CommandFactory.CommandType.Select, p);
            Command badS = CommandFactory.Create(CommandFactory.CommandType.Select, null);

            drawing.Do(c);
            drawing.Do(s);

            Assert.AreEqual(p, drawing.SelectedPokemon);

            drawing.Do(badS);

            Assert.IsNull(drawing.SelectedPokemon);
        }

        [TestMethod]
        public void UndoSelect()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);

            Command s = CommandFactory.Create(CommandFactory.CommandType.Select, p);


            drawing.Do(c);
            drawing.Do(s);
            drawing.Undo();

            Assert.IsNull(drawing.SelectedPokemon);
        }

        [TestMethod]
        public void DoShrink()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);

            Command s = CommandFactory.Create(CommandFactory.CommandType.Shrink, p);
            Command badS = CommandFactory.Create(CommandFactory.CommandType.Shrink, null);

            Size expected = new Size(p.Size.Width - GrowCommand.GROWTH_FACTOR, p.Size.Height - GrowCommand.GROWTH_FACTOR);

            drawing.Do(c);
            drawing.Do(s);

            Assert.AreEqual(expected, p.Size);

            try
            {
                drawing.Do(badS);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UndoShrink()
        {
            Pokemon p = PokemonFactory.Create(Pokemon.PokemonType.Bulbasaur, new Point(15, 15));
            Command c = CommandFactory.Create(CommandFactory.CommandType.Create, p);
            Command s = CommandFactory.Create(CommandFactory.CommandType.Shrink, p);

            Size expected = p.Size;

            drawing.Do(c);
            drawing.Do(s);
            drawing.Undo();

            Assert.AreEqual(expected, p.Size);
        }
    }
}
