import React, { useState } from 'react';


const RatingProfessor = ({ professorName }) => {
  const [workloadRating, setWorkloadRating] = useState(0);
  const [knowledgeRating, setKnowledgeRating] = useState(0);
  const [explanationRating, setExplanationRating] = useState(0);

  const handleSubmit = (event) => {
    event.preventDefault();
    // Submit the ratings here (e.g., send to a server)
    console.log(`Professor: ${professorName}`);
    console.log(`Workload Rating: ${workloadRating}`);
    console.log(`Knowledge Rating: ${knowledgeRating}`);
    console.log(`Explanation Rating: ${explanationRating}`);

    setWorkloadRating(0);
    setKnowledgeRating(0);
    setExplanationRating(0);
  };

  return (
    <div className="rating-professor">
      <h2>Rate Professor: {professorName}</h2>
      <form onSubmit={handleSubmit}>
        <div className="rating-question">
          <label htmlFor="workload">Workload:</label>
          <input
            type="number"
            id="workload"
            name="workload"
            min={0}
            max={5}
            value={workloadRating}
            onChange={(e) => setWorkloadRating(e.target.value)}
          />
          <span outOf>out of 5</span>
        </div>
        <div className="rating-question">
          <label htmlFor="knowledge">Knowledge:</label>
          <input
            type="number"
            id="knowledge"
            name="knowledge"
            min={0}
            max={5}
            value={knowledgeRating}
            onChange={(e) => setKnowledgeRating(e.target.value)}
          />
          <span outOf>out of 5</span>  
        </div>
        <div className="rating-question">
          <label htmlFor="explanation">Explanation:</label>
          <input
            type="number"
            id="explanation"
            name="explanation"
            min={0}
            max={5}
            value={explanationRating}
            onChange={(e) => setExplanationRating(e.target.value)}
          />
          <span outOf>out of 5</span>
        </div>
        <button type="submit">Submit Review</button>
      </form>
    </div>
  );
};

export default RatingProfessor;

// export const RatingProfessor = () => {

//   return(
//     <>
//     <div>
//     <meta charSet="UTF-8" />
//     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
//     <title>Rate Professor</title>
//     <style dangerouslySetInnerHTML={{__html: "\n    .rating-professor {\n      margin: 2rem auto;\n      padding: 1rem;\n      border: 1px solid #ddd;\n      border-radius: 4px;\n      width: fit-content;\n    }\n\n    .rating-professor h2 {\n      text-align: center;\n      margin-bottom: 1rem;\n    }\n\n    .rating-question {\n      margin-bottom: 0.5rem;\n      display: flex;\n      align-items: center;\n    }\n\n    .rating-question label {\n      flex: 1;\n      margin-right: 1rem;\n    }\n\n    .rating-question input {\n      width: 50px;\n      padding: 5px;\n      border: 1px solid #ccc;\n      border-radius: 3px;\n      text-align: center;\n    }\n\n    .rating-question span[outOf] {\n      font-size: 0.8rem;\n      color: #aaa;\n      margin-left: 5px;\n    }\n\n    button[type=\"submit\"] {\n      background-color: #4CAF50; /* Green */\n      border: none;\n      color: white;\n      padding: 10px 20px;\n      text-align: center;\n      text-decoration: none;\n      display: inline-block;\n      font-size: 16px;\n      margin-top: 1rem;\n      cursor: pointer;\n      border-radius: 4px;\n    }\n  " }} />
//     <div className="rating-professor">
//       <h2>Rate Professor: Professor Name (Replace with Actual Name)</h2>
//       <form>
//         <div className="rating-question">
//           <label htmlFor="workload">Workload:</label>
//           <input type="number" id="workload" name="workload" min={0} max={5} disabled />
//           <span outof>out of 5</span>
//         </div>
//         <div className="rating-question">
//           <label htmlFor="knowledge">Knowledge:</label>
//           <input type="number" id="knowledge" name="knowledge" min={0} max={5} disabled />
//           <span outof>out of 5</span>
//         </div>
//         <div className="rating-question">
//           <label htmlFor="explanation">Explanation:</label>
//           <input type="number" id="explanation" name="explanation" min={0} max={5} disabled />
//           <span outof>out of 5</span>
//         </div>
//         <button type="submit" disabled>Submit Review (Not functional in static HTML)</button>
//       </form>
//     </div>
//   </div>
//   </>
//   )
// }

// export default RatingProfessor; 