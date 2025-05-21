<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
<link rel="icon" type="image/png" href="logo.png">
  <title>Xat2Gether</title>
  <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;700&display=swap" rel="stylesheet">
  <style>
    :root {
      --verde-claro: #c8facc;
      --verde-medio: #93dbbd;
      --verde-intenso: #30bfa3;
      --verde-oscuro: #054d44;
      --blanco: #ffffff;
      --morado-claro: #a695e7;
      --morado-oscuro: #5e2e91;
    }

    * {
      box-sizing: border-box;
      margin: 0;
      padding: 0;
    }

    html {
      scroll-behavior: smooth;
    }

    html, body {
      scroll-snap-type: y mandatory;
      overflow-y: scroll;
      height: 100%;
	overflow: hidden;
    }

    section {
      scroll-snap-align: start;
      height: 100vh;
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      padding: 0 2rem;
    }
	a {
  text-decoration: none;
}

    body {
      font-family: 'Poppins', sans-serif;
      background-color: var(--blanco);
      color: var(--verde-oscuro);
    }

    header {
      position: fixed;
      top: 0;
      width: 100%;
      z-index: 1000;
      display: flex;
      justify-content: space-between;
      align-items: center;
      background-color: var(--blanco);
      padding: 1rem 2rem;
      border-bottom: 1px solid #e0e0e0;
    }

    .logo {
      display: flex;
      align-items: center;
      cursor: pointer;
    }

    .logo img {
      height: 50px;
      margin-right: 10px;
    }

    .logo span {
      font-size: 1.5rem;
      font-weight: bold;
      color: var(--verde-oscuro);
    }

    nav a {
      margin-left: 1.5rem;
      color: var(--verde-oscuro);
      text-decoration: none;
      font-weight: 500;
    }

    nav a:hover {
      text-decoration: none;
    }

    .hero {
      background-color: var(--verde-claro);
      text-align: center;
    }

    .hero h1 {
      font-size: 3rem;
      margin-bottom: 1rem;
    }

    .hero p {
      font-size: 1.3rem;
      margin-bottom: 2rem;
      color: #333;
    }

    .boton-grupo {
      display: flex;
      justify-content: center;
      gap: 2rem;
      margin-top: 1rem;
      flex-wrap: wrap;
    }

    .boton-descarga-win {
      padding: 0.8rem 1.5rem;
      background-color: var(--verde-intenso);
      color: var(--blanco);
      border: none;
      border-radius: 6px;
      font-size: 0.9rem;
      cursor: pointer;
      display: flex;
      align-items: center;
      gap: 0.5rem;
      transition: background-color 0.3s ease;
    }

    .boton-descarga-win img {
      height: 20px;
    }

    .boton-descarga-win:hover {
      background-color: #249e8b;
    }

    .caracteristicas {
      background-color: var(--verde-medio);
      flex-direction: row;
      gap: 2rem;
    }

    .bloque-caracteristica {
      background-color: #79d0b3;
      padding: 2rem;
      border-radius: 12px;
      width: 300px;
      box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
      text-align: center;
    }
    .bloque-caracteristica h3 {
      margin-bottom: 1rem;
      font-size: 1.3rem;
    }

    .bloque-caracteristica p {
      font-size: 1rem;
    }

    .capturas {
      background-color: #f9f9f9;
      text-align: center;
    }

    .capturas h2 {
      margin-bottom: 2rem;
      font-size: 2rem;
    }

    .carousel {
      position: relative;
      width: 100%;
      max-width: 800px;
      margin: 0 auto;
      aspect-ratio: 16 / 9;
    }

    .carousel img {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      object-fit: contain;
      display: none;
      border-radius: 10px;
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
    }

    .carousel img.active {
      display: block;
    }

    .carousel-buttons {
      margin-top: 2rem;
      display: flex;
      justify-content: center;
      gap: 1rem;
    }

    .carousel-buttons button {
      background-color: var(--verde-intenso);
      border: none;
      color: var(--blanco);
      padding: 0.6rem 1.2rem;
      border-radius: 4px;
      cursor: pointer;
      font-size: 1rem;
    }

    .weissmann {
      background: linear-gradient(135deg, var(--morado-claro), var(--morado-oscuro));
      color: white;
      text-align: center;
    }

    .weissmann img {
      height: auto;
      max-height: 150px;
      max-width: 300px;
      margin-bottom: 1rem;
    }

    .weissmann h2 {
      font-size: 2.5rem;
      margin-bottom: 1rem;
    }

    .weissmann p {
      font-size: 1.2rem;
    }

    footer {
      background-color: var(--verde-intenso);
      color: var(--blanco);
      text-align: center;
      padding: 2rem 1rem;
    }

    footer a {
      color: var(--blanco);
      text-decoration: underline;
    }
  </style>
</head>
<body>
  <header>
    <a class="logo" href="index.html">
      <img src="logo.png" alt="Logo Xat2Gether">
      <span>Xat2Gether</span>
    </a>
    <nav>
      <a href="#">Inicio</a>
      <a href="#caracteristicas">Características</a>
      <a href="descarga/Xat2Gether.apk" download class="boton-descarga">Descargar</a>
    </nav>
  </header>

  <section class="hero">
    <h1>Chat Local Ultra Cifrado</h1>
    <p>Conectividad segura sin internet, diseñada para privacidad extrema.</p>
    <div class="boton-grupo">
      <a class="boton-descarga-win" href="descarga/cliente.exe" download>
        <img src="windows-icon.png" alt="Windows"> Descargar Cliente
      </a>
      <a class="boton-descarga-win" href="descarga/host.exe" download>
        <img src="windows-icon.png" alt="Windows"> Descargar Host
      </a>
    </div>
  </section>

  <section class="caracteristicas" id="caracteristicas">
    <div class="bloque-caracteristica">
      <h3>Privacidad Total</h3>
      <p>Cifrado local entre dispositivos sin servidores externos.</p>
    </div>
    <div class="bloque-caracteristica">
      <h3>Conexión Offline</h3>
      <p>Funciona en modo local sin necesidad de conexión a Internet.</p>
    </div>
    <div class="bloque-caracteristica">
      <h3>Diseño Intuitivo</h3>
      <p>Interfaz clara, moderna y centrada en la experiencia de usuario.</p>
    </div>
  </section>

  <section class="capturas">
    <h2>Capturas de la Aplicación</h2>
    <div class="carousel">
      <img src="cap1.png" alt="Captura 1" class="active">
      <img src="cap2.png" alt="Captura 2">
    </div>
    <div class="carousel-buttons">
      <button onclick="cambiarCaptura(-1)">Anterior</button>
      <button onclick="cambiarCaptura(1)">Siguiente</button>
    </div>
  </section>

  <section class="weissmann">
    <img src="wm.png" alt="Logo Weissmann">
    <h2>WEISSMANN</h2>
    <p>Privacidad, integridad y soberanía digital — impulsado con visión.<br><strong>Privacidad al 100%. No a la recopilación de datos.</strong></p>
  </section>

  <footer>
    <p>&copy; 2025 Xat2Gether | Esta página no recopila datos.</p>
  </footer>

  <script>
    const imagenes = document.querySelectorAll('.carousel img');
    let indiceActual = 0;

    function cambiarCaptura(direccion) {
      imagenes[indiceActual].classList.remove('active');
      indiceActual = (indiceActual + direccion + imagenes.length) % imagenes.length;
      imagenes[indiceActual].classList.add('active');
    }
  </script>
</body>
</html>