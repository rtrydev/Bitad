import { Link } from "react-router-dom";
import { HashLink } from "react-router-hash-link";
import styles from "./Footer.module.css";
import Container from "../UI/Container";
import ImageAsLink from "../UI/ImageAsLink";
import Copyrights from "./Copyrights";

import bg from "../../assets/css/Backgrounds.module.css";
import typography from "../../assets/css/Typography.module.css";
import patron from "../../assets/images/becon.png";
import patron1 from "../../assets/images/FabLab-logo.png";
import patron2 from "../../assets/images/radio-bielsko.svg";
import fbLogo from "../../assets/images/fb-logo.svg";
import ytLogo from "../../assets/images/yt-logo.svg";
import twLogo from "../../assets/images/tw-logo.svg";

function Footer() {
  return (
    <footer
      className={`${typography["small-p"]} ${bg["footer-background"]} ${styles.footer}`}
    >
      <Container>
        <div className={styles.footer__wrapper}>
          <div>
            <h4>Reset</h4>
            <Link to="/" className={typography["nav-link"]}>
              O konferencji
            </Link>
            <HashLink to="/#sponsors" className={typography["nav-link"]}>
              Sponsorzy
            </HashLink>
            <HashLink to="/agenda#agenda" className={typography["nav-link"]}>
              Agenda
            </HashLink>
          </div>
          <div className={styles["patrons-wrapper"]}>
            <div className={styles.patrons}>
              <h4>Partnerzy</h4>
              <div className={styles.patrons__wrapper}>
                <ImageAsLink
                  isExternalLink={true}
                  src={patron1}
                  alt="FabLab"
                  to="https://www.facebook.com/fablab24/"
                />
                <ImageAsLink
                  isExternalLink={true}
                  src={patron}
                  alt="Becon"
                  to="https://www.facebook.com/klubbecon/"
                />
              </div>
            </div>
            <div className={styles["media-patrons"]}>
              <h4>Patronat medialny</h4>
              <div className={styles.patrons__wrapper}>
                <ImageAsLink
                  isExternalLink={true}
                  src={patron2}
                  alt="Radio Bielsko"
                  to="https://www.radiobielsko.pl/"
                />
              </div>
            </div>
          </div>
          <div>
            <h4>Dane kontaktowe</h4>
            <p>
              Reset, <br />
              Willowa 2, <br />
              Bielsko-Bia??a 43-300
            </p>
            <a href="mailto:reset@ath.bielsko.pl">reset@ath.bielsko.pl</a>
          </div>
          {process.env.REACT_APP_ENABLE_REGISTRATION === "enabled" && (
            <div>
              <h4>Do??acz do nas</h4>
              <p>
                Zarejestruj si?? i zosta?? uczestnikiem konferencji Beskid IT
                Academic Day ju?? teraz. Nie zwlekaj, miejsca s?? ograniczone.
              </p>
              <Link
                to="/registration"
                className={`${typography.button} ${typography["nav-link"]}`}
              >
                Rejestracja
              </Link>
            </div>
          )}
          <div>
            <h4>Poznaj nas bli??ej!</h4>
            <p>Znajdziesz nas r??wnie?? w mediach spo??eczno??ciowych.</p>
            <div className={styles.socialmedia}>
              <ImageAsLink
                isExternalLink={true}
                src={fbLogo}
                alt="Facebook"
                to="https://www.facebook.com/ResetATH"
              />
              <ImageAsLink
                isExternalLink={true}
                src={ytLogo}
                alt="Youtube"
                to="https://www.youtube.com/channel/UCBiN0uFfdjb-Q0gtqqwCgWw"
              />
              <ImageAsLink
                isExternalLink={true}
                src={twLogo}
                alt="Twitter"
                to="https://twitter.com/resetath"
              />
            </div>
          </div>
        </div>
        <Copyrights />
      </Container>
    </footer>
  );
}

export default Footer;
