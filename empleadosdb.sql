-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-02-2019 a las 23:03:45
-- Versión del servidor: 10.1.19-MariaDB
-- Versión de PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `empleadosdb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `id` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Posicion` varchar(50) NOT NULL,
  `Oficina` varchar(50) NOT NULL,
  `Salario` int(11) NOT NULL,
  `RutaImagen` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`id`, `Nombre`, `Posicion`, `Oficina`, `Salario`, `RutaImagen`) VALUES
(1, 'Alvaro Alvarez', 'Desarrollador', 'CABA', 123, '~/CargaArchivos/Imagenes/1191500579.jpg'),
(2, 'Juan Perez', 'Vendedor', 'Palermo', 12313, '~/CargaArchivos/Imagenes/4193118699.jpg'),
(3, 'José', 'Martinez', 'Belgrano', 2321, '~/CargaArchivos/Imagenes/3194452063.gif'),
(4, 'Maria Mercedez', 'Desarrolladora Jr', 'Avellaneda', 12000, '~/CargaArchivos/Imagenes/2190941367.jpg');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
