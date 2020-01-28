namespace HerczegKristofFejlabuak.Logic.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using HerczegKristofFejlabuak.Data;
    using HerczegKristofFejlabuak.Logic;
    using HerczegKristofFejlabuak.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests Repo and Logic methods.
    /// </summary>
    public class TestAll
    {

        private static Mock<IRepository<classification>> mockrepocl = new Mock<IRepository<classification>>(MockBehavior.Loose);
        private static Mock<IRepository<subclass>> mockreposub;
        private static Mock<IRepository<species>> mockreposp;
        private static ILogic<species> logicSpecies;
        private static ILogic<classification> logicClassi;
        private static ILogic<subclass> logicSub;
        private static LogicOther oLogic;

        private static List<species> _listsp;
        private static List<classification> _listcl;
        private static List<subclass> _listsub;

        /// <summary>
        /// Setup mokced Repos for theests.
        /// </summary>
        [OneTimeSetUp]
        public static void SetupRpeos()
        {
            mockrepocl = new Mock<IRepository<classification>>();
            mockreposp = new Mock<IRepository<species>>();
            mockreposub = new Mock<IRepository<subclass>>();
            logicSpecies = new Logic<species>(mockreposp.Object);

            _listsp = new List<species>();
            _listsp.Add(new species() { legnagyobb_meret = "22m", atlagos_meret = "18m", cute = 1, felfedezes = 1888, genus_name = "Liocranchia", megjelenes = "Orvodivician", species_name = "Nori" });
            _listsp.Add(new species() { legnagyobb_meret = "10m", atlagos_meret = "7m", cute = 0, felfedezes = 1860, genus_name = "Liocranchia", megjelenes = "Orvodivician", species_name = "sanyi" });

            _listcl = new List<classification>();
            _listcl.Add(new classification { cthulh_aproved = 0, deep_able = 1, family = "test",  genus_name = "test", order_ = "test", special_apparance = " ", subclass_name = "Orthoceratoidea", });
            _listcl.Add(new classification { cthulh_aproved = 0, deep_able = 1, family = "test", genus_name = "bob", order_ = "test", special_apparance = " ", subclass_name = "Orthoceratoidea", });
            _listsub = new List<subclass>();
            _listsub.Add(new subclass() { belso_szavazas_eredmenye = 10, external_shell = 0, kihalt = 1, megjelenes_idoszaka = "asd", megtalalas_eve = 1984, subclass_name = "asd" });
            _listsub.Add(new subclass() { belso_szavazas_eredmenye = 10, external_shell = 0, kihalt = 1, megjelenes_idoszaka = "asd", megtalalas_eve = 1984, subclass_name = "nemasd" });
        }

        /// <summary>
        /// Tests Create.
        /// </summary>
        [Test]
        public void CreateSpeciesTest()
        {
            // Arange
            species testspecie = new species() { legnagyobb_meret = "10m", atlagos_meret = "7m", cute = 0, felfedezes = 1860, genus_name = "Liocranchia", megjelenes = "Orvodivician", species_name = "juli" };
            mockreposp.CallBase = true;
            mockreposp.Setup(x => x.GetOne(It.IsAny<string>())).Returns((species)null);
            mockreposp.Setup(x => x.Create(It.IsAny<species>())).Callback<species>(y => _listsp.Add(y));

            // Act, Assert
            Assert.That(_listsp.Count, Is.EqualTo(2));
            mockreposp.Object.Create(testspecie);
            Assert.That(_listsp.Count, Is.EqualTo(3));
            mockreposp.Verify(x => x.Create(testspecie), Times.AtLeastOnce);
        }

        /// <summary>
        /// ReadOne methdo test on species.
        /// </summary>
        [Test]
        public void ReadOneTest()
        {
            // Arrange
            string singleinput = "Nori";
            species s = new species() { legnagyobb_meret = "10m", atlagos_meret = "7m", cute = 0, felfedezes = 1860, genus_name = "Liocranchia", megjelenes = "Orvodivician", species_name = "Nori" };

            mockreposp.CallBase = true;
            mockreposp.Setup(x => x.GetOne(It.IsAny<string>())).Returns(s);

            // Act, Assert
            Assert.That(logicSpecies.ReadOne(singleinput).ToString(), Is.EqualTo(s.ToString()));
        }

        /// <summary>
        /// Update Tests, with Verify.
        /// </summary>
        [Test]
        public void UpdateClassification()
        {
            // Arrange
            classification cl = new classification() { cthulh_aproved = 0, deep_able = 1, family = "other", genus_name = "asd", order_ = "asd", special_apparance = "asd", subclass_name = "Orthoceratoidea", };
            mockrepocl.CallBase = true;
            mockrepocl.Setup(x => x.GetOne(It.IsAny<string>())).Returns(new classification() { cthulh_aproved = 0, deep_able = 1, family = "asd", genus_name = "asd", order_ = "asd", special_apparance = "asd", subclass_name = "Orthoceratoidea", });
            logicClassi = new Logic<classification>(mockrepocl.Object);

            // Act,Assert
            logicClassi.Update(cl, "asd");
            mockrepocl.Verify(x => x.Update("asd", cl), Times.AtLeastOnce());
        }

        /// <summary>
        /// Delete tests, with Asserts and verify.
        /// </summary>
        [Test]
        public void DeleteSub_class()
        {
            // Arange
            string delete = "asd";
            mockreposub.Setup(x => x.GetOne(It.IsAny<string>())).Returns(new subclass() { belso_szavazas_eredmenye = 10, external_shell = 0, kihalt = 1, megjelenes_idoszaka = "asd", megtalalas_eve = 1984, subclass_name = "asd" });
            mockreposub.Setup(m => m.Delete(It.IsAny<string>())).Callback<string>(y => _listsub.Remove(_listsub.Find(x => x.subclass_name == y)));
            logicSub = new Logic<subclass>(mockreposub.Object);

            // Act,Assert
            Assert.That(_listsub.Count<subclass>, Is.EqualTo(2));
            logicSub.Delete(delete);
            Assert.That(_listsub.Count<subclass>, Is.EqualTo(1));
            mockreposub.Verify(x => x.Delete(delete), Times.AtLeastOnce);
        }

        /// <summary>
        /// GetAll test, with Assers on logic and Verify on mocked repo.
        /// </summary>
        [Test]
        public void GetAll_classification()
        {
            // Arange
            List<classification> cl = new List<classification>();
            cl.Add(new classification() { cthulh_aproved = 0, deep_able = 1, family = "other", genus_name = "asd", order_ = "asd", special_apparance = "asd", subclass_name = "Orthoceratoidea", });
            cl.Add(new classification() { cthulh_aproved = 0, deep_able = 1, family = "asd", genus_name = "Nori", order_ = "asd", special_apparance = "asd", subclass_name = "Orthoceratoidea", });
            mockrepocl.CallBase = true;
            mockrepocl.Setup(x => x.GetAll()).Returns(cl.AsQueryable());
            logicClassi = new Logic<classification>(mockrepocl.Object);

            // Act, Assert
            mockrepocl.Object.GetAll();
            mockrepocl.Verify(x => x.GetAll(), Times.AtLeastOnce());
            Assert.That(logicClassi.GetAll().ToString(), Is.EqualTo(cl.AsQueryable().ToString()));
        }

        /// <summary>
        /// Test if Logic gives back null, as mockrepo is empty and verify if repo method runs.
        /// </summary>
        [Test]
        public void BranchWriteOutTest()
        {
            // Arange
            oLogic = new LogicOther(mockreposub.Object, mockreposp.Object, mockrepocl.Object);
            mockrepocl.CallBase = true;

            // Act, Assert
            Assert.That(oLogic.BranchWriteout(It.IsAny<string>()), Is.Null);
            mockreposp.Verify(x => x.Short(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test if Logic gives back null, as mockrepo is empty and verify if repo method runds.
        /// </summary>
        [Test]

        public void SpeciesUnderTest()
        {
            // Arange
            oLogic = new LogicOther(mockreposub.Object, mockreposp.Object, mockrepocl.Object);
            mockrepocl.CallBase = true;

            // Act, Assert
            Assert.That(oLogic.FamilyCount(), Is.Null);
            mockreposp.Verify(x => x.Group(), Times.AtLeastOnce());
        }

        /// <summary>
        /// Test if Logic gives back null, as mockrepo is empty and verify if repo method runds.
        /// </summary>
        [Test]

        public void FamilyUnderTest()
        {
            // Arange
            oLogic = new LogicOther(mockreposub.Object, mockreposp.Object, mockrepocl.Object);
            mockrepocl.CallBase = true;

            // Act, Assert
            Assert.That(oLogic.SpeciesUnderSubClassCount(), Is.Null);
            mockreposp.Verify(x => x.GroupSpecies(), Times.AtLeastOnce());
        }
    }
}
