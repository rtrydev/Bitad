import ImageAsLink from "../UI/ImageAsLink";

function Sponsor(props) {
  return (
    <ImageAsLink
      to={props.webpage}
      src={props.picture}
      alt={props.name}
      isExternalLink={true}
    />
  );
}

export default Sponsor;
