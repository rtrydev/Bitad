import styles from "./Sponsors.module.css";
import Rank from "./Rank";

const filterByRank = (rank, array) => {
  return array.filter((e) => e.rank === rank);
};

function Sponsors(props) {
  const sponsors = props.sponsors;

  const diamond = filterByRank(1, sponsors);
  const gold = filterByRank(2, sponsors);
  const silver = filterByRank(3, sponsors);

  return (
    <div className={styles.sponsors}>
      {diamond.length !== 0 && (
        <Rank title="Diamentowi sponsorzy" sponsors={diamond} />
      )}
      {gold.length !== 0 && <Rank title="Złoci sponsorzy" sponsors={gold} />}
      {silver.length !== 0 && (
        <Rank title="Srebrni sponsorzy" sponsors={silver} />
      )}
    </div>
  );
}

export default Sponsors;
