-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-03-2020 a las 05:29:40
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.2.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `enfermeria_utem`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `carreras`
--

CREATE TABLE `carreras` (
  `id_carrera` int(11) NOT NULL,
  `nombre_carrera` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `carreras`
--

INSERT INTO `carreras` (`id_carrera`, `nombre_carrera`) VALUES
(1, 'T.S.U Tecnologías de la Información y Comunicación'),
(2, 'ING.Tecnologías de la Información'),
(3, 'Química área Industrial'),
(4, 'Procesos Químicos'),
(5, 'Contaduría'),
(6, 'Financiera Fiscal'),
(7, 'Mantenimiento en Maquinaria Pesada'),
(8, 'Mantenimiento Industrial'),
(9, 'Logística área Cadena de Suministros'),
(10, 'Logística Comercial Global'),
(11, 'Operaciones Comerciales Internacionales'),
(12, 'Energías Renovables'),
(13, 'Ingeniería en Energía Renovables'),
(14, 'Gastronomía'),
(15, 'Licenciatura en Gastronomía'),
(16, 'Diseño y Gestión en Redes Logísticas'),
(17, 'No Aplica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fecha_caducidad`
--

CREATE TABLE `fecha_caducidad` (
  `id_fecha_caducidad` int(11) NOT NULL,
  `fecha_caducidad` date DEFAULT NULL,
  `cantidad` int(4) DEFAULT NULL,
  `unidades` varchar(25) COLLATE utf8_unicode_ci DEFAULT NULL,
  `fk_medicamento` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `fecha_caducidad`
--

INSERT INTO `fecha_caducidad` (`id_fecha_caducidad`, `fecha_caducidad`, `cantidad`, `unidades`, `fk_medicamento`) VALUES
(1, '2020-03-12', 0, 'caja', 2),
(2, '2020-03-12', 2, 'caja', 3),
(3, '2020-04-24', 40, 'pieza', 4),
(4, '2020-04-24', 3, 'caja', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `medicamento`
--

CREATE TABLE `medicamento` (
  `id_medicamento` int(11) NOT NULL,
  `medicamento` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `activo` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `medicamento`
--

INSERT INTO `medicamento` (`id_medicamento`, `medicamento`, `activo`) VALUES
(1, 'No Aplica', 1),
(2, 'parasetamol', 1),
(3, 'parasetamol', 1),
(4, 'eropasleep', 1),
(5, 'eropasleep', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pasiente`
--

CREATE TABLE `pasiente` (
  `id_pasient` int(11) NOT NULL,
  `nombres` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `apellidos` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  `numero_control` varchar(8) COLLATE utf8_unicode_ci DEFAULT NULL,
  `fecha_atendida` datetime NOT NULL DEFAULT current_timestamp(),
  `tipo` enum('alumno','administrativo','docente','externo') COLLATE utf8_unicode_ci DEFAULT NULL,
  `motivo` text COLLATE utf8_unicode_ci DEFAULT NULL,
  `fk_medicamento` int(11) DEFAULT NULL,
  `fk_servicio` int(11) DEFAULT NULL,
  `fk_carrera` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `pasiente`
--

INSERT INTO `pasiente` (`id_pasient`, `nombres`, `apellidos`, `numero_control`, `fecha_atendida`, `tipo`, `motivo`, `fk_medicamento`, `fk_servicio`, `fk_carrera`) VALUES
(1, 'josue', 'Fierro', '20170094', '2020-03-12 02:09:44', 'alumno', 'poblemas para respirar', 3, 1, 2),
(2, 'josue', 'Fierro', '20170094', '2020-03-13 19:38:42', 'alumno', 'poblemas para respirar', 3, 3, 3),
(3, 'josue', 'Fierro', '20170094', '2020-03-13 19:47:24', 'alumno', 'poblemas para respirar', 3, 11, 2),
(4, 'josue', 'Fierro', '20170094', '2020-03-13 19:47:30', 'alumno', 'poblemas para respirar', 3, 13, 2),
(10, 'josue', 'Fierro', '20170094', '2020-03-13 20:00:30', 'docente', 'poblemas para respirar', 3, 37, 3),
(15, 'josue', 'Fierro', '20170094', '2020-03-14 00:48:59', 'alumno', 'poblemas para respirar', 3, 53, 2),
(21, 'josueE', 'Fierro', '20170094', '2020-03-15 00:39:47', 'alumno', 'poblemas para respirar', 3, 55, 2),
(22, 'WW', 'Fierro', '20170094', '2020-03-15 12:13:06', 'alumno', 'poblemas para respirar', 3, 57, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicios`
--

CREATE TABLE `servicios` (
  `id_servicio` int(11) NOT NULL,
  `curacion` varchar(2) COLLATE utf8_unicode_ci DEFAULT NULL,
  `toma_TA` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `inyeccion` varchar(2) COLLATE utf8_unicode_ci DEFAULT NULL,
  `toma_glucosa` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `servicios`
--

INSERT INTO `servicios` (`id_servicio`, `curacion`, `toma_TA`, `inyeccion`, `toma_glucosa`) VALUES
(1, 'si', 'no', 'si', '10'),
(2, 'si', 'no', 'si', '10'),
(3, 'no', '100/2', 'no', '10'),
(4, 'no', '100/2', 'no', '10'),
(5, 'no', '100/2', 'no', '10'),
(6, 'no', '100/2', 'no', '10'),
(7, 'si', 'no', 'si', '10'),
(8, 'si', 'no', 'si', '10'),
(9, 'si', 'no', 'si', '10'),
(10, 'si', 'no', 'si', '10'),
(11, 'si', 'no', 'si', '10'),
(12, 'si', 'no', 'si', '10'),
(13, 'si', 'no', 'si', '10'),
(14, 'si', 'no', 'si', '10'),
(15, 'si', 'no', 'si', '10'),
(16, 'si', 'no', 'si', '10'),
(17, 'si', 'no', 'si', '10'),
(18, 'si', 'no', 'si', '10'),
(19, 'si', 'no', 'si', '10'),
(20, 'si', 'no', 'si', '10'),
(21, 'si', 'no', 'si', '10'),
(22, 'si', 'no', 'si', '10'),
(23, 'si', 'no', 'si', '10'),
(24, 'si', 'no', 'si', '10'),
(25, 'si', 'no', 'si', '10'),
(26, 'si', 'no', 'si', '10'),
(27, 'si', 'no', 'si', '10'),
(28, 'si', 'no', 'si', '10'),
(29, 'no', '100/2', 'no', '10'),
(30, 'no', '100/2', 'no', '10'),
(31, 'no', '100/2', 'no', '10'),
(32, 'no', '100/2', 'no', '10'),
(33, 'si', 'no', 'si', '10'),
(34, 'si', 'no', 'si', '10'),
(35, 'si', 'no', 'si', '10'),
(36, 'si', 'no', 'si', '10'),
(37, 'si', 'no', 'si', '10'),
(38, 'si', 'no', 'si', '10'),
(39, 'si', 'no', 'si', '10'),
(40, 'si', 'no', 'si', '10'),
(41, 'si', 'no', 'si', '10'),
(42, 'si', 'no', 'si', '10'),
(43, 'si', 'no', 'si', '10'),
(44, 'si', 'no', 'si', '10'),
(45, 'si', 'no', 'si', '10'),
(46, 'si', 'no', 'si', '10'),
(47, 'si', 'no', 'si', '10'),
(48, 'si', 'no', 'si', '10'),
(49, 'si', 'no', 'si', '10'),
(50, 'si', 'no', 'si', '10'),
(51, 'si', 'no', 'si', '10'),
(52, 'si', 'no', 'si', '10'),
(53, 'no', '100/2', 'no', '10'),
(54, 'no', '100/2', 'no', '10'),
(55, 'si', 'no', 'si', '10'),
(56, 'si', 'no', 'si', '10'),
(57, 'si', 'no', 'si', '10'),
(58, 'si', 'no', 'si', '10');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuarios` int(11) NOT NULL,
  `nombre_usuario` varchar(25) COLLATE utf8_unicode_ci DEFAULT NULL,
  `contraseña` varchar(25) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_usuarios`, `nombre_usuario`, `contraseña`) VALUES
(1, 'josue', '123'),
(2, 'Alan', '123'),
(3, 'vanessa', '456');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `carreras`
--
ALTER TABLE `carreras`
  ADD PRIMARY KEY (`id_carrera`);

--
-- Indices de la tabla `fecha_caducidad`
--
ALTER TABLE `fecha_caducidad`
  ADD PRIMARY KEY (`id_fecha_caducidad`),
  ADD KEY `fk_medicamento` (`fk_medicamento`);

--
-- Indices de la tabla `medicamento`
--
ALTER TABLE `medicamento`
  ADD PRIMARY KEY (`id_medicamento`);

--
-- Indices de la tabla `pasiente`
--
ALTER TABLE `pasiente`
  ADD PRIMARY KEY (`id_pasient`),
  ADD KEY `fk_medicamento` (`fk_medicamento`),
  ADD KEY `fk_servicio` (`fk_servicio`),
  ADD KEY `fk_carrera` (`fk_carrera`);

--
-- Indices de la tabla `servicios`
--
ALTER TABLE `servicios`
  ADD PRIMARY KEY (`id_servicio`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuarios`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `carreras`
--
ALTER TABLE `carreras`
  MODIFY `id_carrera` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `fecha_caducidad`
--
ALTER TABLE `fecha_caducidad`
  MODIFY `id_fecha_caducidad` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `medicamento`
--
ALTER TABLE `medicamento`
  MODIFY `id_medicamento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `pasiente`
--
ALTER TABLE `pasiente`
  MODIFY `id_pasient` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de la tabla `servicios`
--
ALTER TABLE `servicios`
  MODIFY `id_servicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuarios` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `fecha_caducidad`
--
ALTER TABLE `fecha_caducidad`
  ADD CONSTRAINT `fecha_caducidad_ibfk_1` FOREIGN KEY (`fk_medicamento`) REFERENCES `medicamento` (`id_medicamento`);

--
-- Filtros para la tabla `pasiente`
--
ALTER TABLE `pasiente`
  ADD CONSTRAINT `pasiente_ibfk_1` FOREIGN KEY (`fk_medicamento`) REFERENCES `medicamento` (`id_medicamento`) ON DELETE NO ACTION,
  ADD CONSTRAINT `pasiente_ibfk_2` FOREIGN KEY (`fk_servicio`) REFERENCES `servicios` (`id_servicio`) ON DELETE NO ACTION,
  ADD CONSTRAINT `pasiente_ibfk_3` FOREIGN KEY (`fk_carrera`) REFERENCES `carreras` (`id_carrera`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
