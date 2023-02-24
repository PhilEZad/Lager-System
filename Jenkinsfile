pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'cd Backend/API'
                sh pwd
                sh ls
                sh 'dotnet restore API.csproj'
                sh 'dotnet build API.csproj'
                echo 'build complete'
            }
        }
        stage('Test') {
            steps {
                //
                echo 'test'
            }
        }
        stage('Deploy') {
            steps {
                //
                echo 'deploy'
            }
        }
    }
}