import styles from "./Rank.module.css";
import Sponsor from "./Sponsor";

function Rank(props) {
  const sponsors = props.sponsors.map((sponsor) => {
    return (
      <Sponsor
        key={sponsor.name}
        webpage={sponsor.webpage}
        picture={sponsor.picture}
        name={sponsor.name}
      />
    );
  });

  return (
    <div>
      <h4>{props.title}</h4>
      <div className={styles.rank__sponosrs}>{sponsors}</div>
    </div>
  );
}

export default Rank;
