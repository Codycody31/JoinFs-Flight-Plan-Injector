SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
CREATE TABLE `flightplan` (
  `id` int(11) NOT NULL,
  `callsign` varchar(10) NOT NULL,
  `aircraft` varchar(10) NOT NULL,
  `departure` varchar(4) NOT NULL,
  `arrival` varchar(4) NOT NULL,
  `route` varchar(250) NOT NULL,
  `remarks` varchar(250) NOT NULL,
  `cruisingaltitude` varchar(10) NOT NULL,
  `flightrule` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
ALTER TABLE `flightplan`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `flightplan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;
