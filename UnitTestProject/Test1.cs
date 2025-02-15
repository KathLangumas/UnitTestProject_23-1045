namespace UnitTestProject
{
    [TestClass]
    public sealed class Test1
    {
            private BibliotecaService _bibliotecaService;

            [TestInitialize]
            public void Initialize()
            {
                _bibliotecaService = new BibliotecaService();
            }

            [TestMethod]
            public void AgregarLibro_LibroValido_RetornaTrue()
            {
                // Arrange
                var libro = new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes" };

                // Act
                var resultado = _bibliotecaService.AgregarLibro(libro);

                // Assert
                Assert.IsTrue(resultado);
                Assert.AreEqual(1, libro.Id);
                Assert.IsTrue(libro.Disponible);
            }

            [TestMethod]
            public void AgregarLibro_LibroSinTitulo_RetornaFalse()
            {
                // Arrange
                var libro = new Libro { Autor = "Miguel de Cervantes" };

                // Act
                var resultado = _bibliotecaService.AgregarLibro(libro);

                // Assert
                Assert.IsFalse(resultado);
            }

            [TestMethod]
            public void PrestarLibro_LibroDisponible_RetornaTrue()
            {
                // Arrange
                var libro = new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes" };
                _bibliotecaService.AgregarLibro(libro);

                // Act
                var resultado = _bibliotecaService.PrestarLibro(1);

                // Assert
                Assert.IsTrue(resultado);
                Assert.IsFalse(_bibliotecaService.BuscarLibroPorId(1).Disponible);
            }

            [TestMethod]
            public void DevolverLibro_LibroPrestado_RetornaTrue()
            {
                // Arrange
                var libro = new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes" };
                _bibliotecaService.AgregarLibro(libro);
                _bibliotecaService.PrestarLibro(1);

                // Act
                var resultado = _bibliotecaService.DevolverLibro(1);

                // Assert
                Assert.IsTrue(resultado);
                Assert.IsTrue(_bibliotecaService.BuscarLibroPorId(1).Disponible);
            }

            [TestMethod]
            public void ObtenerLibrosDisponibles_RetornaSoloDisponibles()
            {
                // Arrange
                var libro1 = new Libro { Titulo = "Don Quijote", Autor = "Miguel de Cervantes" };
                var libro2 = new Libro { Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez" };
                _bibliotecaService.AgregarLibro(libro1);
                _bibliotecaService.AgregarLibro(libro2);
                _bibliotecaService.PrestarLibro(1);

                // Act
                var librosDisponibles = _bibliotecaService.ObtenerLibrosDisponibles();

                // Assert
                Assert.AreEqual(1, librosDisponibles.Count);
                Assert.AreEqual(2, librosDisponibles[0].Id);
            }
        }
        
}
