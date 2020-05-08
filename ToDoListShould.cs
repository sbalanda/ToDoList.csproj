using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace ToDoList
{
    public class ToDoListShould
    {
        private const int userA = 10;
        private const int userB = 11;
        private const int userC = 14;

        private IToDoList list;

        [SetUp]
        public void SetUp()
        {
            list = new ToDoList();
        }


        [Test]
        public void Rem_Entry()
        {
            list.AddEntry(42, 10, "Hello", 100);
            list.AddEntry(42, 11, "Hello 1", 120);
            list.AddEntry(30, 10, "Hello 2", 130);
            list.AddEntry(30, 11, "Hello 3", 95);

            list.RemoveEntry(42, 10, 110);
            list.RemoveEntry(42, 12, 95);
            list.RemoveEntry(42, 11, 115);
            list.RemoveEntry(30, 12, 112);
            list.RemoveEntry(30, 10, 113);

            AssertEntries(
                Entry.Undone(42, "Hello 1"),
                Entry.Undone(30, "Hello 2")
            );
        }


        [Test]
        public void Add_Entry()
        {
            list.AddEntry(42, userA, "Build project", 100);

            AssertEntries(Entry.Undone(42, "Build project"));
        }

        [Test]
        public void Add_Entry10_Different()
        {
            list.AddEntry(0, 10, "Build project0", 100);
            list.AddEntry(1, 11, "Build project1", 101);
            list.AddEntry(2, 10, "Build project2", 102);
            list.AddEntry(3, 11, "Build project3", 103);
            list.AddEntry(4, 12, "Build project4", 104);
            list.AddEntry(5, 12, "Build project5", 105);
            list.AddEntry(6, 10, "Build project6", 106);
            list.AddEntry(7, 10, "Build project7", 107);
            list.AddEntry(8, 10, "Build project8", 108);
            list.AddEntry(9, 12, "Build project9", 109);

            AssertEntries(Entry.Undone(0, "Build project0"),
                Entry.Undone(1, "Build project1"),
                Entry.Undone(2, "Build project2"),
                Entry.Undone(3, "Build project3"),
                Entry.Undone(4, "Build project4"),
                Entry.Undone(5, "Build project5"),
                Entry.Undone(6, "Build project6"),
                Entry.Undone(7, "Build project7"),
                Entry.Undone(8, "Build project8"),
                Entry.Undone(9, "Build project9"));
        }

        [Test]
        public void Add_Entry10_No_Different()
        {
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);

            AssertEntries(Entry.Undone(42, "Build project"));
        }

        [Test]
        public void Add_Entry20_Different()
        {
            list.AddEntry(0, 10, "Build project0", 100);
            list.AddEntry(1, 11, "Build project1", 101);
            list.AddEntry(2, 10, "Build project2", 102);
            list.AddEntry(3, 11, "Build project3", 103);
            list.AddEntry(4, 12, "Build project4", 104);
            list.AddEntry(5, 12, "Build project5", 105);
            list.AddEntry(6, 10, "Build project6", 106);
            list.AddEntry(7, 10, "Build project7", 107);
            list.AddEntry(8, 10, "Build project8", 108);
            list.AddEntry(9, 12, "Build project9", 109);
            list.AddEntry(10, 10, "Build project10", 110);
            list.AddEntry(11, 11, "Build project11", 111);
            list.AddEntry(12, 10, "Build project12", 112);
            list.AddEntry(13, 11, "Build project13", 113);
            list.AddEntry(14, 12, "Build project14", 114);
            list.AddEntry(15, 12, "Build project15", 115);
            list.AddEntry(16, 10, "Build project16", 116);
            list.AddEntry(17, 10, "Build project17", 117);
            list.AddEntry(18, 10, "Build project18", 118);
            list.AddEntry(19, 12, "Build project19", 119);

            AssertEntries(Entry.Undone(0, "Build project0"),
                Entry.Undone(1, "Build project1"),
                Entry.Undone(2, "Build project2"),
                Entry.Undone(3, "Build project3"),
                Entry.Undone(4, "Build project4"),
                Entry.Undone(5, "Build project5"),
                Entry.Undone(6, "Build project6"),
                Entry.Undone(7, "Build project7"),
                Entry.Undone(8, "Build project8"),
                Entry.Undone(9, "Build project9"),
                Entry.Undone(10, "Build project10"),
                Entry.Undone(11, "Build project11"),
                Entry.Undone(12, "Build project12"),
                Entry.Undone(13, "Build project13"),
                Entry.Undone(14, "Build project14"),
                Entry.Undone(15, "Build project15"),
                Entry.Undone(16, "Build project16"),
                Entry.Undone(17, "Build project17"),
                Entry.Undone(18, "Build project18"),
                Entry.Undone(19, "Build project19"));
        }

        [Test]
        public void Add_Entry20_No_Different()
        {
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);

            AssertEntries(Entry.Undone(42, "Build project"));
        }

        [Test]
        public void Add_Entry40_Different()
        {
            list.AddEntry(0, 10, "Build project0", 100);
            list.AddEntry(1, 11, "Build project1", 101);
            list.AddEntry(2, 10, "Build project2", 102);
            list.AddEntry(3, 11, "Build project3", 103);
            list.AddEntry(4, 12, "Build project4", 104);
            list.AddEntry(5, 12, "Build project5", 105);
            list.AddEntry(6, 10, "Build project6", 106);
            list.AddEntry(7, 10, "Build project7", 107);
            list.AddEntry(8, 10, "Build project8", 108);
            list.AddEntry(9, 12, "Build project9", 109);
            list.AddEntry(10, 10, "Build project10", 110);
            list.AddEntry(11, 11, "Build project11", 111);
            list.AddEntry(12, 10, "Build project12", 112);
            list.AddEntry(13, 11, "Build project13", 113);
            list.AddEntry(14, 12, "Build project14", 114);
            list.AddEntry(15, 12, "Build project15", 115);
            list.AddEntry(16, 10, "Build project16", 116);
            list.AddEntry(17, 10, "Build project17", 117);
            list.AddEntry(18, 10, "Build project18", 118);
            list.AddEntry(19, 12, "Build project19", 119);
            list.AddEntry(20, 10, "Build project20", 120);
            list.AddEntry(21, 11, "Build project21", 121);
            list.AddEntry(22, 10, "Build project22", 122);
            list.AddEntry(23, 11, "Build project23", 123);
            list.AddEntry(24, 12, "Build project24", 124);
            list.AddEntry(25, 12, "Build project25", 125);
            list.AddEntry(26, 10, "Build project26", 126);
            list.AddEntry(27, 10, "Build project27", 127);
            list.AddEntry(28, 10, "Build project28", 128);
            list.AddEntry(29, 12, "Build project29", 129);
            list.AddEntry(30, 10, "Build project30", 120);
            list.AddEntry(31, 11, "Build project31", 121);
            list.AddEntry(32, 10, "Build project32", 122);
            list.AddEntry(33, 11, "Build project33", 123);
            list.AddEntry(34, 12, "Build project34", 124);
            list.AddEntry(35, 12, "Build project35", 125);
            list.AddEntry(36, 10, "Build project36", 126);
            list.AddEntry(37, 10, "Build project37", 127);
            list.AddEntry(38, 10, "Build project38", 128);
            list.AddEntry(39, 12, "Build project39", 129);

            AssertEntries(Entry.Undone(0, "Build project0"),
                Entry.Undone(1, "Build project1"),
                Entry.Undone(2, "Build project2"),
                Entry.Undone(3, "Build project3"),
                Entry.Undone(4, "Build project4"),
                Entry.Undone(5, "Build project5"),
                Entry.Undone(6, "Build project6"),
                Entry.Undone(7, "Build project7"),
                Entry.Undone(8, "Build project8"),
                Entry.Undone(9, "Build project9"),
                Entry.Undone(10, "Build project10"),
                Entry.Undone(11, "Build project11"),
                Entry.Undone(12, "Build project12"),
                Entry.Undone(13, "Build project13"),
                Entry.Undone(14, "Build project14"),
                Entry.Undone(15, "Build project15"),
                Entry.Undone(16, "Build project16"),
                Entry.Undone(17, "Build project17"),
                Entry.Undone(18, "Build project18"),
                Entry.Undone(19, "Build project19"),
                Entry.Undone(20, "Build project20"),
                Entry.Undone(21, "Build project21"),
                Entry.Undone(22, "Build project22"),
                Entry.Undone(23, "Build project23"),
                Entry.Undone(24, "Build project24"),
                Entry.Undone(25, "Build project25"),
                Entry.Undone(26, "Build project26"),
                Entry.Undone(27, "Build project27"),
                Entry.Undone(28, "Build project28"),
                Entry.Undone(29, "Build project29"),
                Entry.Undone(30, "Build project30"),
                Entry.Undone(31, "Build project31"),
                Entry.Undone(32, "Build project32"),
                Entry.Undone(33, "Build project33"),
                Entry.Undone(34, "Build project34"),
                Entry.Undone(35, "Build project35"),
                Entry.Undone(36, "Build project36"),
                Entry.Undone(37, "Build project37"),
                Entry.Undone(38, "Build project38"),
                Entry.Undone(39, "Build project39"));
        }

        [Test]
        public void Add_Entry40_No_Different()
        {
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);

            AssertEntries(Entry.Undone(42, "Build project"));
        }


        [Test]
        public void Add_Entry80_Different()
        {
            list.AddEntry(0, 10, "Build project0", 100);
            list.AddEntry(1, 11, "Build project1", 101);
            list.AddEntry(2, 10, "Build project2", 102);
            list.AddEntry(3, 11, "Build project3", 103);
            list.AddEntry(4, 12, "Build project4", 104);
            list.AddEntry(5, 12, "Build project5", 105);
            list.AddEntry(6, 10, "Build project6", 106);
            list.AddEntry(7, 10, "Build project7", 107);
            list.AddEntry(8, 10, "Build project8", 108);
            list.AddEntry(9, 12, "Build project9", 109);
            list.AddEntry(10, 10, "Build project10", 110);
            list.AddEntry(11, 11, "Build project11", 111);
            list.AddEntry(12, 10, "Build project12", 112);
            list.AddEntry(13, 11, "Build project13", 113);
            list.AddEntry(14, 12, "Build project14", 114);
            list.AddEntry(15, 12, "Build project15", 115);
            list.AddEntry(16, 10, "Build project16", 116);
            list.AddEntry(17, 10, "Build project17", 117);
            list.AddEntry(18, 10, "Build project18", 118);
            list.AddEntry(19, 12, "Build project19", 119);
            list.AddEntry(20, 10, "Build project20", 120);
            list.AddEntry(21, 11, "Build project21", 121);
            list.AddEntry(22, 10, "Build project22", 122);
            list.AddEntry(23, 11, "Build project23", 123);
            list.AddEntry(24, 12, "Build project24", 124);
            list.AddEntry(25, 12, "Build project25", 125);
            list.AddEntry(26, 10, "Build project26", 126);
            list.AddEntry(27, 10, "Build project27", 127);
            list.AddEntry(28, 10, "Build project28", 128);
            list.AddEntry(29, 12, "Build project29", 129);
            list.AddEntry(30, 10, "Build project30", 120);
            list.AddEntry(31, 11, "Build project31", 121);
            list.AddEntry(32, 10, "Build project32", 122);
            list.AddEntry(33, 11, "Build project33", 123);
            list.AddEntry(34, 12, "Build project34", 124);
            list.AddEntry(35, 12, "Build project35", 125);
            list.AddEntry(36, 10, "Build project36", 126);
            list.AddEntry(37, 10, "Build project37", 127);
            list.AddEntry(38, 10, "Build project38", 128);
            list.AddEntry(39, 12, "Build project39", 129);
            list.AddEntry(40, 10, "Build project40", 100);
            list.AddEntry(41, 11, "Build project41", 101);
            list.AddEntry(42, 10, "Build project42", 102);
            list.AddEntry(43, 11, "Build project43", 103);
            list.AddEntry(44, 12, "Build project44", 104);
            list.AddEntry(45, 12, "Build project45", 105);
            list.AddEntry(46, 10, "Build project46", 106);
            list.AddEntry(47, 10, "Build project47", 107);
            list.AddEntry(48, 10, "Build project48", 108);
            list.AddEntry(49, 12, "Build project49", 109);
            list.AddEntry(50, 10, "Build project50", 110);
            list.AddEntry(51, 11, "Build project51", 111);
            list.AddEntry(52, 10, "Build project52", 112);
            list.AddEntry(53, 11, "Build project53", 113);
            list.AddEntry(54, 12, "Build project54", 114);
            list.AddEntry(55, 12, "Build project55", 115);
            list.AddEntry(56, 10, "Build project56", 116);
            list.AddEntry(57, 10, "Build project57", 117);
            list.AddEntry(58, 10, "Build project58", 118);
            list.AddEntry(59, 12, "Build project59", 119);
            list.AddEntry(60, 10, "Build project60", 120);
            list.AddEntry(61, 11, "Build project61", 121);
            list.AddEntry(62, 10, "Build project62", 122);
            list.AddEntry(63, 11, "Build project63", 123);
            list.AddEntry(64, 12, "Build project64", 124);
            list.AddEntry(65, 12, "Build project65", 125);
            list.AddEntry(66, 10, "Build project66", 126);
            list.AddEntry(67, 10, "Build project67", 127);
            list.AddEntry(68, 10, "Build project68", 128);
            list.AddEntry(69, 12, "Build project69", 129);
            list.AddEntry(70, 10, "Build project70", 120);
            list.AddEntry(71, 11, "Build project71", 121);
            list.AddEntry(72, 10, "Build project72", 122);
            list.AddEntry(73, 11, "Build project73", 123);
            list.AddEntry(74, 12, "Build project74", 124);
            list.AddEntry(75, 12, "Build project75", 125);
            list.AddEntry(76, 10, "Build project76", 126);
            list.AddEntry(77, 10, "Build project77", 127);
            list.AddEntry(78, 10, "Build project78", 128);
            list.AddEntry(79, 12, "Build project79", 129);

            AssertEntries(Entry.Undone(0, "Build project0"),
                Entry.Undone(1, "Build project1"),
                Entry.Undone(2, "Build project2"),
                Entry.Undone(3, "Build project3"),
                Entry.Undone(4, "Build project4"),
                Entry.Undone(5, "Build project5"),
                Entry.Undone(6, "Build project6"),
                Entry.Undone(7, "Build project7"),
                Entry.Undone(8, "Build project8"),
                Entry.Undone(9, "Build project9"),
                Entry.Undone(10, "Build project10"),
                Entry.Undone(11, "Build project11"),
                Entry.Undone(12, "Build project12"),
                Entry.Undone(13, "Build project13"),
                Entry.Undone(14, "Build project14"),
                Entry.Undone(15, "Build project15"),
                Entry.Undone(16, "Build project16"),
                Entry.Undone(17, "Build project17"),
                Entry.Undone(18, "Build project18"),
                Entry.Undone(19, "Build project19"),
                Entry.Undone(20, "Build project20"),
                Entry.Undone(21, "Build project21"),
                Entry.Undone(22, "Build project22"),
                Entry.Undone(23, "Build project23"),
                Entry.Undone(24, "Build project24"),
                Entry.Undone(25, "Build project25"),
                Entry.Undone(26, "Build project26"),
                Entry.Undone(27, "Build project27"),
                Entry.Undone(28, "Build project28"),
                Entry.Undone(29, "Build project29"),
                Entry.Undone(30, "Build project30"),
                Entry.Undone(31, "Build project31"),
                Entry.Undone(32, "Build project32"),
                Entry.Undone(33, "Build project33"),
                Entry.Undone(34, "Build project34"),
                Entry.Undone(35, "Build project35"),
                Entry.Undone(36, "Build project36"),
                Entry.Undone(37, "Build project37"),
                Entry.Undone(38, "Build project38"),
                Entry.Undone(39, "Build project39"),
                Entry.Undone(40, "Build project40"),
                Entry.Undone(41, "Build project41"),
                Entry.Undone(42, "Build project42"),
                Entry.Undone(43, "Build project43"),
                Entry.Undone(44, "Build project44"),
                Entry.Undone(45, "Build project45"),
                Entry.Undone(46, "Build project46"),
                Entry.Undone(47, "Build project47"),
                Entry.Undone(48, "Build project48"),
                Entry.Undone(49, "Build project49"),
                Entry.Undone(50, "Build project50"),
                Entry.Undone(51, "Build project51"),
                Entry.Undone(52, "Build project52"),
                Entry.Undone(53, "Build project53"),
                Entry.Undone(54, "Build project54"),
                Entry.Undone(55, "Build project55"),
                Entry.Undone(56, "Build project56"),
                Entry.Undone(57, "Build project57"),
                Entry.Undone(58, "Build project58"),
                Entry.Undone(59, "Build project59"),
                Entry.Undone(60, "Build project60"),
                Entry.Undone(61, "Build project61"),
                Entry.Undone(62, "Build project62"),
                Entry.Undone(63, "Build project63"),
                Entry.Undone(64, "Build project64"),
                Entry.Undone(65, "Build project65"),
                Entry.Undone(66, "Build project66"),
                Entry.Undone(67, "Build project67"),
                Entry.Undone(68, "Build project68"),
                Entry.Undone(69, "Build project69"),
                Entry.Undone(70, "Build project70"),
                Entry.Undone(71, "Build project71"),
                Entry.Undone(72, "Build project72"),
                Entry.Undone(73, "Build project73"),
                Entry.Undone(74, "Build project74"),
                Entry.Undone(75, "Build project75"),
                Entry.Undone(76, "Build project76"),
                Entry.Undone(77, "Build project77"),
                Entry.Undone(78, "Build project78"),
                Entry.Undone(79, "Build project79"));
        }

        [Test]
        public void Add_Entry80_No_Different()
        {
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);
            list.AddEntry(42, userA, "Build project", 100);

            AssertEntries(Entry.Undone(42, "Build project"));
        }

        //Не добавлять элемент, когда он был удален с большой меткой времени
        [Test]
        public void Not_Add_Item_When_It_Was_Removed_With_Greater_Timestamp()
        {
            list.RemoveEntry(42, userA, 101);
            list.AddEntry(42, userA, "Build project", 100);

            AssertListEmpty();
        }

        [Test]
        public void Not_Remove_Entry_If_Removal_Timestamp_Is_Less_Than_Entry_Timestamp(
            [Values(userA, userB, userC)] int removingUserId)
        {
            list.AddEntry(42, userA, "Build project", 100);

            list.RemoveEntry(42, removingUserId, 99);

            AssertEntries(Entry.Undone(42, "Build project"));
        }

        [Test]
        public void Remove_Entry(
            [Values(userA, userB, userC)] int removingUserId,
            [Values(200, 101, 100)] long removingTimestamp)
        {
            list.AddEntry(42, userA, "Build project", 100);

            list.RemoveEntry(42, removingUserId, removingTimestamp);

            AssertListEmpty();
        }

        [Test]
        public void Remove_Entry_10()
        {
            list.AddEntry(0, 10, "Build project0", 100);
            list.AddEntry(1, 11, "Build project1", 101);
            list.AddEntry(2, 10, "Build project2", 102);
            list.AddEntry(3, 11, "Build project3", 103);
            list.AddEntry(4, 12, "Build project4", 104);
            list.AddEntry(5, 12, "Build project5", 105);
            list.AddEntry(6, 10, "Build project6", 106);
            list.AddEntry(7, 10, "Build project7", 107);
            list.AddEntry(8, 10, "Build project8", 108);
            list.AddEntry(9, 12, "Build project9", 109);

            list.RemoveEntry(0, 10, 100);
            list.RemoveEntry(1, 11, 101);
            list.RemoveEntry(2, 10, 102);
            list.RemoveEntry(3, 11, 103);
            list.RemoveEntry(4, 12, 104);
            list.RemoveEntry(5, 12, 105);
            list.RemoveEntry(6, 10, 106);
            list.RemoveEntry(7, 10, 107);
            list.RemoveEntry(8, 10, 108);
            list.RemoveEntry(9, 12, 109);

            AssertListEmpty();
        }

        [Test]
        public void Remove_Entry_20()
        {
            list.AddEntry(0, 10, "Build project0", 100);
            list.AddEntry(1, 11, "Build project1", 101);
            list.AddEntry(2, 10, "Build project2", 102);
            list.AddEntry(3, 11, "Build project3", 103);
            list.AddEntry(4, 12, "Build project4", 104);
            list.AddEntry(5, 12, "Build project5", 105);
            list.AddEntry(6, 10, "Build project6", 106);
            list.AddEntry(7, 10, "Build project7", 107);
            list.AddEntry(8, 10, "Build project8", 108);
            list.AddEntry(9, 12, "Build project9", 109);
            list.AddEntry(10, 10, "Build project10", 110);
            list.AddEntry(11, 11, "Build project11", 111);
            list.AddEntry(12, 10, "Build project12", 112);
            list.AddEntry(13, 11, "Build project13", 113);
            list.AddEntry(14, 12, "Build project14", 114);
            list.AddEntry(15, 12, "Build project15", 115);
            list.AddEntry(16, 10, "Build project16", 116);
            list.AddEntry(17, 10, "Build project17", 117);
            list.AddEntry(18, 10, "Build project18", 118);
            list.AddEntry(19, 12, "Build project19", 119);

            list.RemoveEntry(0, 10, 100);
            list.RemoveEntry(1, 11, 101);
            list.RemoveEntry(2, 10, 102);
            list.RemoveEntry(3, 11, 103);
            list.RemoveEntry(4, 12, 104);
            list.RemoveEntry(5, 12, 105);
            list.RemoveEntry(6, 10, 106);
            list.RemoveEntry(7, 10, 107);
            list.RemoveEntry(8, 10, 108);
            list.RemoveEntry(9, 12, 109);

            list.RemoveEntry(10, 10, 110);
            list.RemoveEntry(11, 11, 111);
            list.RemoveEntry(12, 10, 112);
            list.RemoveEntry(13, 11, 113);
            list.RemoveEntry(14, 12, 114);
            list.RemoveEntry(15, 12, 115);
            list.RemoveEntry(16, 10, 116);
            list.RemoveEntry(17, 10, 117);
            list.RemoveEntry(18, 10, 118);
            list.RemoveEntry(19, 12, 119);

            AssertListEmpty();
        }

        [Test]
        public void Updates_Name_When_Entry_With_Greater_Timestamp_Added([Values(userA, userB, userC)] int updatingUserId)
        {
            list.AddEntry(42, userB, "Build project", 100);

            list.AddEntry(42, updatingUserId, "Create project", 105);

            AssertEntries(Entry.Undone(42, "Create project"));
        }

        [Test]
        public void Not_Update_Name_When_Less_Experienced_User_Adds_Entry()
        {
            list.AddEntry(42, userA, "Create project", 100);

            list.AddEntry(42, userB, "Build project", 100);

            AssertEntries(Entry.Undone(42, "Create project"));
        }

        [Test]
        public void Add_Several_Entries()
        {
            list.AddEntry(42, userA, "Create audio subsystem", 150);
            list.AddEntry(90, userB, "Create video subsystem", 125);
            list.AddEntry(74, userC, "Create input subsystem", 117);

            AssertEntries(
                Entry.Undone(42, "Create audio subsystem"),
                Entry.Undone(90, "Create video subsystem"),
                Entry.Undone(74, "Create input subsystem")
            );
        }

        [Test]
        public void Mark_Entry_Done(
            [Values(userA, userB, userC)] int markingUserId,
            [Values(100, 95, 107)] long markTimestamp)
        {
            list.AddEntry(42, userB, "Create project", 100);

            list.MarkDone(42, markingUserId, markTimestamp);

            AssertEntries(Entry.Done(42, "Create project"));
        }

        [Test]
        // Отметить выполнено перед удалением
        public void Mark_Done_Before_Removal()
        {
            list.AddEntry(42, userA, "Create project", 110);

            list.MarkDone(42, userA, 115);
            list.RemoveEntry(42, userA, 118);
            list.AddEntry(42, userA, "Create project", 120);

            AssertEntries(Entry.Done(42, "Create project"));
        }


        [Test]
        public void Mark_Entry_Done_When_Entry_Does_Not_Exists(
            [Values(userA, userB, userC)] int markingUserId,
            [Values(100, 95, 107)] long markTimestamp)
        {
            list.MarkDone(42, markingUserId, markTimestamp);

            list.AddEntry(42, userB, "Create project", 100);

            AssertEntries(Entry.Done(42, "Create project"));
        }

        [Test]
        public void Mark_Undone()
        {
            list.AddEntry(42, userA, "Create project", 100);
            list.MarkDone(42, userB, 105);

            list.MarkUndone(42, userC, 106);

            AssertEntries(Entry.Undone(42, "Create project"));
        }

        [Test]
        public void Not_Mark_Undone_When_Timestamp_Less_Than_Done_Mark_Timestamp2()
        {
            list.AddEntry(42, userA, "Create project", 100);
            list.MarkDone(42, userB, 105);

            list.MarkUndone(42, userC, 107);
            list.MarkUndone(42, userC, 99);

            AssertEntries(Entry.Undone(42, "Create project"));
        }

        //
        [Test]
        public void Mark_Undone_When_Timestamps_Match()
        {
            list.AddEntry(42, userA, "Create project", 100);
            list.MarkDone(42, userB, 105);

            list.MarkUndone(42, userB, 105);

            AssertEntries(Entry.Undone(42, "Create project"));
        }

        [Test]
        public void Dismiss_User_That_Did_Nothing1()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.AddEntry(43, userB, "Introduce autotests1", 101);
            list.AddEntry(42, userB, "Introduce autotests2", 102);
            list.MarkDone(42, userB, 105);

            list.DismissUser(userC);

            AssertEntries(Entry.Done(42, "Introduce autotests2"),
                Entry.Undone(43, "Introduce autotests1"));
        }


        [Test]
        public void Dismiss_User_That_Did_Nothing()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userB, 105);

            list.DismissUser(userC);

            AssertEntries(Entry.Done(42, "Introduce autotests"));
        }

        [Test]
        public void Dismiss_Creation_1()
        {
            list.DismissUser(10);
            list.AddEntry(42, 10, "Introduce autotests", 100);
            list.MarkDone(42, 11, 105);

            AssertListEmpty();
        }


        [Test]
        public void Dismiss_Creation()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userB, 105);

            list.DismissUser(userA);

            AssertListEmpty();
        }

        [Test]
        public void Dismiss_Name_Updates()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.AddEntry(42, userB, "Introduce nice autotests", 105);

            list.DismissUser(userB);

            AssertEntries(Entry.Undone(42, "Introduce autotests"));
        }

        [Test]
        public void Dismiss_Done()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userB, 105);

            list.DismissUser(userB);

            AssertEntries(Entry.Undone(42, "Introduce autotests"));
        }

        [Test]
        public void Dismiss_Undone()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userA, 105);
            list.MarkUndone(42, userB, 107);

            list.DismissUser(userB);

            AssertEntries(Entry.Done(42, "Introduce autotests"));
        }

        [Test]
        public void Allow_User_That_Did_Nothing()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userB, 105);
            list.DismissUser(userC);

            list.AllowUser(userC);

            AssertEntries(Entry.Done(42, "Introduce autotests"));
        }

        [Test]
        public void Allow_Creation()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userB, 105);
            list.DismissUser(userA);

            list.AllowUser(userA);

            AssertEntries(Entry.Done(42, "Introduce autotests"));
        }

        [Test]
        public void Allow_Name_Updates()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.AddEntry(42, userB, "Introduce nice autotests", 105);
            list.DismissUser(userB);

            list.AllowUser(userB);

            AssertEntries(Entry.Undone(42, "Introduce nice autotests"));
        }

        [Test]
        public void Allow_Done()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userB, 105);
            list.DismissUser(userB);

            list.AllowUser(userB);

            AssertEntries(Entry.Done(42, "Introduce autotests"));
        }

        [Test]
        public void Allow_Undone()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userA, 105);
            list.MarkUndone(42, userB, 107);
            list.DismissUser(userB);

            list.AllowUser(userB);

            AssertEntries(Entry.Undone(42, "Introduce autotests"));
        }

        [Test]
        public void Allow_Undone1()
        {
            list.AddEntry(42, userA, "Introduce autotests", 100);
            list.MarkDone(42, userA, 105);
            list.MarkUndone(42, userB, 107);
            list.RemoveEntry(42, userA, 118);
            list.DismissUser(userB);

            list.AllowUser(userB);

            AssertEntries();
        }

        private void AssertListEmpty()
        {
            list.Should().BeEmpty();
            list.Count.Should().Be(0);
        }

        private void AssertEntries(params Entry[] expected)
        {
            list.Should().BeEquivalentTo(expected.AsEnumerable());
            list.Count.Should().Be(expected.Length);
        }
    }
}