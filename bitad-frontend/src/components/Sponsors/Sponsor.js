import ImageAsLink from "../UI/ImageAsLink";

function Sponsor(props) {
  return (
    <ImageAsLink to={props.webpage} src={props.picture} alt={props.name} />
  );
}

export default Sponsor;
