-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 06 nov. 2020 à 11:01
-- Version du serveur :  10.4.14-MariaDB
-- Version de PHP : 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `supermarche`
--

DELIMITER $$
--
-- Procédures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `Graph` ()  NO SQL
select nom,dte FROM graphenligne
UNION

Select nomR,dte from rayon,graphenligne
where nomR=nom
and nomR not in (select nom from graphenligne where total=0 group by dte)$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `employe`
--

CREATE TABLE `employe` (
  `numE` int(10) NOT NULL,
  `prenomE` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `employe`
--

INSERT INTO `employe` (`numE`, `prenomE`) VALUES
(1, 'Olivier'),
(2, 'Marie'),
(3, 'Benjamin'),
(4, 'Christophe'),
(5, 'Virginie'),
(6, 'Lilou'),
(7, 'Noa'),
(8, 'Dede'),
(9, 'Milo'),
(10, 'Test');

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `graphenligne`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `graphenligne` (
`dte` int(2)
,`total` decimal(32,0)
,`nom` varchar(20)
);

-- --------------------------------------------------------

--
-- Structure de la table `rayon`
--

CREATE TABLE `rayon` (
  `numR` int(11) NOT NULL,
  `nomR` varchar(20) NOT NULL,
  `numSecteur` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `rayon`
--

INSERT INTO `rayon` (`numR`, `nomR`, `numSecteur`) VALUES
(1, 'Fromages', 1),
(2, 'Charcuterie', 2),
(3, 'Viande', 2),
(4, 'Légumes', 1),
(5, 'Barbecue', 2);

-- --------------------------------------------------------

--
-- Structure de la table `secteur`
--

CREATE TABLE `secteur` (
  `numS` int(10) NOT NULL,
  `nomS` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `secteur`
--

INSERT INTO `secteur` (`numS`, `nomS`) VALUES
(1, 'Produits frais'),
(2, 'Viande / Poisson');

-- --------------------------------------------------------

--
-- Structure de la table `travailler`
--

CREATE TABLE `travailler` (
  `codeE` int(11) NOT NULL,
  `codeR` int(11) NOT NULL,
  `date` date NOT NULL,
  `temps` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `travailler`
--

INSERT INTO `travailler` (`codeE`, `codeR`, `date`, `temps`) VALUES
(1, 1, '2015-03-03', 26),
(1, 1, '2015-03-11', 4),
(1, 1, '2015-03-23', 5),
(1, 1, '2015-03-26', 11),
(1, 1, '2015-03-27', 3),
(1, 1, '2015-04-08', 4),
(1, 1, '2015-05-01', 4),
(1, 1, '2015-05-03', 23),
(1, 1, '2015-10-14', 10),
(1, 1, '2016-04-26', 6),
(1, 2, '2015-03-11', 7),
(1, 4, '2015-03-09', 20),
(2, 1, '2015-03-05', 80),
(2, 2, '2015-03-27', 6),
(2, 2, '2015-05-03', 51),
(2, 3, '2015-05-03', 7),
(3, 1, '2015-03-10', 6),
(3, 2, '2015-03-25', 11),
(3, 3, '2020-11-06', 2),
(3, 5, '2015-05-03', 4),
(3, 5, '2015-10-24', 65),
(4, 1, '2015-06-16', 42),
(4, 3, '2015-05-01', 7),
(4, 4, '2015-04-23', 4),
(5, 2, '2015-10-13', 33),
(5, 4, '2015-10-19', 34),
(6, 1, '2016-04-26', 4),
(6, 2, '2016-04-26', 3),
(6, 3, '2016-04-26', 7),
(7, 1, '2016-04-26', 6),
(8, 2, '2016-04-26', 3),
(10, 3, '2020-11-06', 6),
(10, 4, '2020-11-06', 3);

-- --------------------------------------------------------

--
-- Structure de la vue `graphenligne`
--
DROP TABLE IF EXISTS `graphenligne`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `graphenligne`  AS  select month(`travailler`.`date`) AS `dte`,sum(`travailler`.`temps`) AS `total`,`rayon`.`nomR` AS `nom` from (`rayon` join `travailler`) where `rayon`.`numR` = `travailler`.`codeR` group by month(`travailler`.`date`),`rayon`.`nomR` ;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `employe`
--
ALTER TABLE `employe`
  ADD PRIMARY KEY (`numE`);

--
-- Index pour la table `rayon`
--
ALTER TABLE `rayon`
  ADD PRIMARY KEY (`numR`),
  ADD KEY `numSecteur` (`numSecteur`);

--
-- Index pour la table `secteur`
--
ALTER TABLE `secteur`
  ADD PRIMARY KEY (`numS`);

--
-- Index pour la table `travailler`
--
ALTER TABLE `travailler`
  ADD PRIMARY KEY (`codeE`,`codeR`,`date`),
  ADD KEY `codeR` (`codeR`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `secteur`
--
ALTER TABLE `secteur`
  MODIFY `numS` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `rayon`
--
ALTER TABLE `rayon`
  ADD CONSTRAINT `rayon_ibfk_1` FOREIGN KEY (`numSecteur`) REFERENCES `secteur` (`numS`);

--
-- Contraintes pour la table `travailler`
--
ALTER TABLE `travailler`
  ADD CONSTRAINT `travailler_ibfk_1` FOREIGN KEY (`codeE`) REFERENCES `employe` (`numE`),
  ADD CONSTRAINT `travailler_ibfk_2` FOREIGN KEY (`codeR`) REFERENCES `rayon` (`numR`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
