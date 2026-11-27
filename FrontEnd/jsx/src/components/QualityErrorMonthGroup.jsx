
function getSeverityText(severityId)
{
    switch (severityId)
    {
        case 1:
            return 'Low';
        case 2:
            return 'Medium';
        case 3:
            return 'High';
        default:
            return 'Unknown';
    }
}

export default getSeverityText;
