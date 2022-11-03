import { Link } from "react-router-dom";
import { HashLink } from "react-router-hash-link";
import styles from "./Footer.module.css";
import Container from "../UI/Container";
import ImageAsLink from "../UI/ImageAsLink";
import Copyrights from "./Copyrights";

import bg from "../../assets/css/Backgrounds.module.css";
import typography from "../../assets/css/Typography.module.css";
import patron from "../../assets/images/helion.png";
import patron1 from "../../assets/images/FabLab-logo.png";
import patron2 from "../../assets/images/blackfrog.png";
import patron3 from "../../assets/images/cbsg.png";
import patron4 from "../../assets/images/k.png";
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
                  alt="Helion"
                  to="https://helion.pl/"
                />
                <ImageAsLink
                  isExternalLink={true}
                  src={patron3}
                  alt="Cbsg"
                  to="https://cbsg.pl/"
                />
                <ImageAsLink
                  isExternalLink={true}
                  src={patron2}
                  alt="Blackfrog"
                  to="https://blackfrog.pl/"
                />{" "}
                <ImageAsLink
                  isExternalLink={true}
                  src={patron4}
                  alt="Klub fantastyki kregulec"
                  to="https://kregulec.pl/"
                />
              </div>
            </div>
            {/* <div className={styles["media-patrons"]}>
              <h4>Patronat medialny</h4>
              <div className={styles.patrons__wrapper}>
                <ImageAsLink
                  isExternalLink={true}
                  src={patron2}
                  alt="Radio Bielsko"
                  to="https://www.radiobielsko.pl/"
                />
              </div>
            </div> */}
          </div>
          <div>
            <h4>Dane kontaktowe</h4>
            <p>
              Reset, <br />
              Willowa 2, <br />
              Bielsko-Biała 43-300
            </p>
            <a href="mailto:reset@ath.bielsko.pl">reset@ath.bielsko.pl</a>
          </div>
          {process.env.REACT_APP_ENABLE_REGISTRATION === "enabled" && (
            <div>
              <h4>Dołacz do nas</h4>
              <p>
                Zarejestruj się i zostań uczestnikiem konferencji Beskid IT
                Academic Day już teraz. Nie zwlekaj, miejsca są ograniczone.
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
            <h4>Poznaj nas bliżej!</h4>
            <p>Znajdziesz nas również w mediach społecznościowych.</p>
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
